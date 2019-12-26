using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class TokenServiceBase<T> where T : ITokenResponse, new()
    {
        private readonly HttpClient _httpClient;
        
        protected readonly string ConsumerKey;
        protected readonly string ConsumerSecret;
        protected readonly string CallbackUrl;

        private readonly JsonSerializerSettings _serializerSettings;

        public TokenServiceBase(HttpClient httpClient, IOptions<TokenServiceOptions> options)
            : this(httpClient, options.Value.ConsumerKey, options.Value.ConsumerSecret, options.Value.CallbackUrl)
        {
        }

        public TokenServiceBase(HttpClient httpClient, string consumerKey, string consumerSecret, string callbackUrl)
        {
            if (string.IsNullOrWhiteSpace(consumerKey)) throw new ArgumentNullException(nameof(consumerKey), "Consumer Key must be specified.");
            if (string.IsNullOrWhiteSpace(consumerSecret)) throw new ArgumentNullException(nameof(consumerSecret), "Consumer Secrete must be specified");
            if (string.IsNullOrWhiteSpace(callbackUrl)) throw new ArgumentNullException(nameof(callbackUrl), "Callback URL must be specified");

            _httpClient = httpClient;

            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;

            this.CallbackUrl = callbackUrl;

            _serializerSettings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        protected virtual string ComputeNonce()
        {
            byte[] data = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(data);
            }
            int value = Math.Abs(BitConverter.ToInt32(data, 0));
            return value.ToString();
        }

        protected virtual string ComputeSignature(string baseString, string tokenSecret)
        {
            string key = string.Concat(ConsumerSecret, "&", tokenSecret);

            var encoding = Encoding.ASCII;
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] baseStringBytes = encoding.GetBytes(baseString);
            using (var hmacSha256 = new HMACSHA256(keyBytes))
            {
                byte[] baseStringHash = hmacSha256.ComputeHash(baseStringBytes);
                return Convert.ToBase64String(baseStringHash);
            }
        }

        protected virtual long ComputeTimestamp() => ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

        protected string GetAuthorizationHeaderValue(string account, string requestUrl, string callbackUrl, string httpMethod = "POST")
        {
            var oauthParams = this.GetCommonOAuthParameters();
            oauthParams.Add("oauth_callback", callbackUrl);

            return this.GetAuthorizationHeaderValue(account, requestUrl, oauthParams, httpMethod: httpMethod);
        }

        protected string GetAuthorizationHeaderValue(string account,
                                                     string requestUrl,
                                                     SortedDictionary<string, string> oauthParams,
                                                     string tokenSecret = "",
                                                     string httpMethod = "POST")
        {
            string E(string data) => Uri.EscapeDataString(data);

            var headerBuilder = new StringBuilder(300);
            var baseStringBuilder = new StringBuilder(300);

            headerBuilder.Append($"OAuth realm=\"{E(account.ToUpperInvariant())}\"");
            bool isFirstParam = true;

            foreach (var pair in oauthParams)
            {
                var encodedValue = E(pair.Value);

                if (pair.Key.StartsWith("oauth_"))
                {
                    headerBuilder.Append(", ")
                                .Append(pair.Key)
                                .Append("=\"")
                                .Append(encodedValue)
                                .Append("\"");
                }

                if (!isFirstParam)
                {
                    baseStringBuilder.Append("&");
                }
                else
                {
                    isFirstParam = false;
                }

                baseStringBuilder.Append(pair.Key)
                            .Append("=")
                            .Append(encodedValue);
            }

            string baseString = $"{httpMethod}&{E(requestUrl)}&{E(baseStringBuilder.ToString())}";

            return headerBuilder.Append(", oauth_signature=\"")
                        .Append(E(this.ComputeSignature(baseString, tokenSecret)))
                        .Append("\"")
                        .ToString();
        }

        protected SortedDictionary<string, string> GetCommonOAuthParameters()
        {
            return new SortedDictionary<string, string> {
                { "oauth_consumer_key", ConsumerKey },
                { "oauth_nonce", this.ComputeNonce() },
                { "oauth_signature_method", "HMAC-SHA256" },
                { "oauth_timestamp", this.ComputeTimestamp().ToString() },
                { "oauth_version", "1.0" }
            };
        }

        protected async Task<T> GetErroredResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var erroredResponse = JsonConvert.DeserializeObject<T>(responseBody, _serializerSettings);
            if (erroredResponse.Error != null)
            {
                erroredResponse.Error.StatusCode = response.StatusCode;
            }
            else
            {
                erroredResponse.Error = new ResponseError {
                    Code = "UNEXPECTED_ERROR",
                    Message = responseBody,
                    StatusCode = response.StatusCode
                };
            }
            return erroredResponse;
        }

        protected async Task<T> MakeGetRequest(string account, string url, Func<HttpResponseMessage, Task<T>> successHandler, Func<HttpResponseMessage, Task<T>> failureStatusHandler = null)
        {
            string authorizationHeader = this.GetAuthorizationHeaderValue(account, url, CallbackUrl, "GET");
            return await MakeRequest(authorizationHeader, c => c.GetAsync(url), successHandler);
        }

        protected async Task<T> MakePostRequest(string account, string url, Func<HttpResponseMessage, Task<T>> successHandler, Func<HttpResponseMessage, Task<T>> failureStatusHandler = null)
        {
            string authorizationHeader = this.GetAuthorizationHeaderValue(account, url, CallbackUrl);
            return await MakeRequest(authorizationHeader, c => c.PostAsync(url, null), successHandler);
        }

        protected virtual async Task<T> MakeRequest(string authorizationHeader, Func<HttpClient, Task<HttpResponseMessage>> makeRequestFn, Func<HttpResponseMessage, Task<T>> successHandler)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            const string authorizationHeaderName = "Authorization";
            _httpClient.DefaultRequestHeaders.Remove(authorizationHeaderName);
            _httpClient.DefaultRequestHeaders.Add(authorizationHeaderName, authorizationHeader);

            using (var response = await makeRequestFn(_httpClient))
            {
                return response.IsSuccessStatusCode 
                    ? await successHandler(response) 
                    : await HandleFailureResponse(response);
            }
        }

        protected virtual async Task<T> HandleFailureResponse(HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentLength > 0)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await this.GetErroredResponse(response);
            }
            else
            {
                string message = $"NetSuite returned a non-200 HTTP Status: {(int)response.StatusCode} {response.ReasonPhrase}.";
                return new T {
                    Error = new ResponseError {
                        Code = response.StatusCode.ToString(),
                        Message = message,
                        StatusCode = response.StatusCode
                    }
                };
            }
        }

        protected string Subdomainify(string account) => account.ToLowerInvariant().Replace('_', '-');
    }
}
