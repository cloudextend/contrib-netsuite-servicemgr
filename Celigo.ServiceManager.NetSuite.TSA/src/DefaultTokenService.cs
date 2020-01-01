using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    [Obsolete]
    public class DefaultTokenService: ITokenService
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _callbackUrl;
        private readonly IHttpClientFactory _clientFactory;

        private readonly JsonSerializerSettings _serializerSettings;

        public DefaultTokenService(IHttpClientFactory clientFactory, string consumerKey, string consumerSecret, string callbackUrl)
        {
            if (string.IsNullOrWhiteSpace(consumerKey)) throw new ArgumentNullException(nameof(consumerKey), "Consumer Key must be specified.");
            if (string.IsNullOrWhiteSpace(consumerSecret)) throw new ArgumentNullException(nameof(consumerSecret), "Consumer Secrete must be specified");
            if (string.IsNullOrWhiteSpace(callbackUrl)) throw new ArgumentNullException(nameof(callbackUrl), "Callback URL must be specified");

            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;

            _callbackUrl = callbackUrl;

            _clientFactory = clientFactory;

            _serializerSettings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        public DefaultTokenService(IHttpClientFactory clientFactory, IOptions<TokenServiceOptions> options)
            : this(clientFactory, options.Value.ConsumerKey, options.Value.ConsumerSecret, options.Value.CallbackUrl)
        {
        }

        public async Task<RequestTokenResponse> GetRequestToken(string account) => await this.GetRequestToken(account, _callbackUrl);

        public async Task<RequestTokenResponse> GetRequestToken(string account, string callbackUrl)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            if (callbackUrl == null) throw new ArgumentNullException(nameof(callbackUrl));

            string accountSpecificSubdomain = this.SanitizeForSubdomain(account);
            string url = $"https://{accountSpecificSubdomain}.restlets.api.netsuite.com/rest/requesttoken";

            using (var response = await this.RequestWithBasicOAuthHeader(account, url, HttpMethod.Post))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var resultData = HttpUtility.ParseQueryString(responseBody);

                    var token = resultData.Get("oauth_token").Trim();
                    return new RequestTokenResponse {
                        IsCallbackConfirmed = "true".Equals(resultData.Get("oauth_callback_confirmed").Trim()),
                        Token = token,
                        TokenSecret = resultData.Get("oauth_token_secret").Trim(),
                        Next = $"https://{accountSpecificSubdomain}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token={token}"
                    };
                }
                else if (response.Content.Headers.ContentLength > 0)
                {
                    return await GetErroredResponse<RequestTokenResponse>(response);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
                {
                    return new RequestTokenResponse {
                        Error = new ResponseError {
                            Code = response.StatusCode.ToString(),
                            Message = $"Account {account} may not be configured to support 3-Step Authentication.",
                            StatusCode = response.StatusCode
                        }
                    };
                }
                else
                {
                    return new RequestTokenResponse {
                        Error = new ResponseError {
                            Code = response.StatusCode.ToString(),
                            Message = $"NetSuite returned a non 200 HTTP Status: {(int)response.StatusCode} {response.ReasonPhrase}",
                            StatusCode = response.StatusCode
                        }
                    };
                }
            }
        }

        private async Task<T> GetErroredResponse<T>(HttpResponseMessage response) where T: ITokenResponse
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

        private string SanitizeForSubdomain(string account) => account.ToLowerInvariant().Replace('_', '-');

        private async Task<HttpResponseMessage> PostToTokenEndpoint(string url, string authorizationHeader)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient.DefaultRequestHeaders.Add("Authorization", authorizationHeader);
                return await httpClient.PostAsync(url, null);
            }
        }

        public async Task<AccessTokenResponse> GetAccessToken(string account, string requestToken, string tokenSecret, string verifier)
        {
            var oauthParms = this.GetCommonOAuthParameters();
            oauthParms.Add("oauth_verifier", verifier);
            oauthParms.Add("oauth_token", requestToken);

            string url = $"https://{this.SanitizeForSubdomain(account)}.restlets.api.netsuite.com/rest/accesstoken";
            string authHeaderValue = this.GetAuthorizationHeaderValue(account, url, oauthParms, tokenSecret);

            using (var response = await this.PostToTokenEndpoint(url, authHeaderValue))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseParams = HttpUtility.ParseQueryString(responseBody);
                    return new AccessTokenResponse {
                        Token = responseParams.Get("oauth_token").Trim(),
                        TokenSecret = responseParams.Get("oauth_token_secret").Trim()
                    };
                }
                else if (response.Content.Headers.ContentLength > 0)
                {
                    return await this.GetErroredResponse<AccessTokenResponse>(response);
                }
                else
                {
                    string message = $"NetSuite returned a non-200 HTTP Status: {(int)response.StatusCode} {response.ReasonPhrase}.";
                    return new AccessTokenResponse {
                        Error = new ResponseError {
                            Code = response.StatusCode.ToString(),
                            Message = message,
                            StatusCode = response.StatusCode
                        }
                    };
                }
            }
        }

        private SortedDictionary<string, string> GetCommonOAuthParameters()
        {
            return new SortedDictionary<string, string> {
                { "oauth_consumer_key", _consumerKey },
                { "oauth_nonce", this.ComputeNonce() },
                { "oauth_signature_method", "HMAC-SHA256" },
                { "oauth_timestamp", this.ComputeTimestamp().ToString() },
                { "oauth_version", "1.0" }
            };
        }

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
            string E(string data)
            {
                return Uri.EscapeDataString(data);
            }

            var headerBuilder = new StringBuilder(300);
            var baseStringBuilder = new StringBuilder(300);

            headerBuilder.Append($"OAuth realm=\"{E(account.ToUpperInvariant())}\"");
            bool isFirstParam = true;

            foreach (var pair in oauthParams)
            {
                var encodedValue = E(pair.Value);

                headerBuilder.Append(", ")
                            .Append(pair.Key)
                            .Append("=\"")
                            .Append(encodedValue)
                            .Append("\"");

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

        protected virtual long ComputeTimestamp() => ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

        private string ComputeSignature(string baseString, string tokenSecret)
        {
            string key = string.Concat(_consumerSecret, "&", tokenSecret);

            var encoding = Encoding.ASCII;
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] baseStringBytes = encoding.GetBytes(baseString);
            using (var hmacSha256 = new HMACSHA256(keyBytes))
            {
                byte[] baseStringHash = hmacSha256.ComputeHash(baseStringBytes);
                return Convert.ToBase64String(baseStringHash);
            }
        }

        public async Task RevokeToken(string account, string token)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            string accountSpecificSubdomain = this.SanitizeForSubdomain(account);
            string url = $"htttps://{accountSpecificSubdomain}.restlets.api.netsuite.com/rest/revoketoken?consumerKey={_consumerKey}&token={token}";

            using (var response = await this.RequestWithBasicOAuthHeader(account, url, HttpMethod.Get))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private async Task<HttpResponseMessage> RequestWithBasicOAuthHeader(string account, string url, HttpMethod httpMethod)
        {
            using (var httpClient = _clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string authorizationHeader = this.GetAuthorizationHeaderValue(account, url, _callbackUrl, httpMethod: httpMethod.Method);
                httpClient.DefaultRequestHeaders.Add("Authorization", authorizationHeader);

                if (httpMethod == HttpMethod.Get)
                {
                    return await httpClient.GetAsync(url);
                }
                else if (httpMethod == HttpMethod.Post)
                {
                    return await httpClient.PostAsync(url, null);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(httpMethod), "Only GET and POST are supported.");
                }
            }
        }
    }
}
