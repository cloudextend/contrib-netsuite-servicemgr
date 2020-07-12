using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;

namespace Celigo.ServiceManager.NetSuite.REST
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> Get(string account, Uri requestUri, string token, string tokenSecret);
        Task<HttpResponseMessage> Post<T>(string account, Uri requestUri, string token, string tokenSecret, T content);
    }

    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;

        protected readonly string ConsumerKey;
        protected readonly string ConsumerSecret;

        public virtual string SignatureAlgorithmName
        {
            get {
                Debug.Assert(
                    HasConsistentHashAlgortimOverriding(), 
                    $"If you override either the {nameof(SignatureAlgorithmName)} property or {nameof(ComputeSignature)} method,"
                    + " you should override the other as a best practice, even if they use the same algorithm.");
                return "HMAC-SHA256";
            }
        }

        private bool HasConsistentHashAlgortimOverriding()
        {
            var t = this.GetType();
            if (t == typeof(RestClient)) return true;
                
            var compSigMethod = t.GetMethod(nameof(ComputeSignature), BindingFlags.Instance | BindingFlags.NonPublic);
            var algoNameProp = t.GetProperty(nameof(SignatureAlgorithmName));
            return compSigMethod!.DeclaringType == algoNameProp!.DeclaringType;
        }

        public static JsonSerializerOptions SerializerSettings { get; set; } = new JsonSerializerOptions {
                                                                             IgnoreNullValues = true,
                                                                             PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                                                                         };

        public RestClient(HttpClient httpClient, IOptions<RestClientOptions> options)
            : this(httpClient, options.Value.ConsumerKey, options.Value.ConsumerSecret) { }

        public RestClient(HttpClient httpClient, string consumerKey, string consumerSecret)
        {
            if (string.IsNullOrWhiteSpace(consumerKey))
                throw new ArgumentNullException(nameof(consumerKey), "Consumer Key must be specified.");
            if (string.IsNullOrWhiteSpace(consumerSecret))
                throw new ArgumentNullException(nameof(consumerSecret), "Consumer Secrete must be specified");

            _httpClient = httpClient;

            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
        }

        private void AddQueryParamsFrom(Uri url, SortedDictionary<string, string> signingParams)
        {
            string query = url.Query;
            if (string.IsNullOrEmpty(query)) return;

            var queryParams = HttpUtility.ParseQueryString(query);
            foreach (var param in queryParams.AllKeys)
            {
                signingParams.Add(param, queryParams[param]);
            }
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
        
        protected virtual long ComputeTimestamp() =>
            ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

        protected static StringContent CreateJsonMessageContent<T>(T content) =>
            new StringContent(JsonSerializer.Serialize(content, SerializerSettings), Encoding.UTF8, "application/json");
        
        protected string GetAuthorizationHeaderValue(string account,
                                                     Uri requestUri,
                                                     string token,
                                                     string tokenSecret,
                                                     string httpMethod)
        {
            var oauthParams = this.GetCommonOAuthParameters();
            this.AddQueryParamsFrom(requestUri, oauthParams);
            
            string basePath = requestUri.GetLeftPart(UriPartial.Path);
            return this.GetAuthorizationHeaderValue(account, basePath, oauthParams, token, tokenSecret, httpMethod);
        }
        
        protected string GetAuthorizationHeaderValue(string account,
                                                    string baseUrlPath,
                                                    SortedDictionary<string, string> oauthParams,
                                                    string token,
                                                    string tokenSecret,
                                                    string httpMethod)
        {
            oauthParams.Add("oauth_token", token);
            
            string E(string data) => Uri.EscapeDataString(data);

            var headerBuilder = new StringBuilder(300);
            var baseStringBuilder = new StringBuilder(300);

            headerBuilder.Append($"OAuth realm=\"{E(account.ToUpperInvariant().Replace('_', '-'))}\"");
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

            string baseString = $"{httpMethod}&{E(baseUrlPath)}&{E(baseStringBuilder.ToString())}";

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
                { "oauth_signature_method", this.SignatureAlgorithmName },
                { "oauth_timestamp", this.ComputeTimestamp().ToString() },
                { "oauth_version", "1.0" }
            };
        }

        public Task<HttpResponseMessage> Get(string account, Uri requestUri, string token, string tokenSecret)
        {
            string authorizationHeader = this.GetAuthorizationHeaderValue(account, requestUri, token, tokenSecret, "GET");
            return SendRequest(HttpMethod.Get, requestUri, authorizationHeader);
        }

        public Task<HttpResponseMessage> Post<T>(string account, Uri requestUri, string token, string tokenSecret, T content)
        {
            string authorizationHeader = this.GetAuthorizationHeaderValue(account, requestUri, token, tokenSecret, "POST");
            
            return SendRequest(HttpMethod.Post, 
                                requestUri, 
                                authorizationHeader,
                                CreateJsonMessageContent(content));
        }

        protected virtual Task<HttpResponseMessage> SendRequest(
            HttpMethod method,
            Uri url,
            string authorizationHeader,
            HttpContent content = null,
            Action<HttpRequestMessage> configureRequest = null)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = content;

            configureRequest?.Invoke(request);

            return _httpClient.SendAsync(request);
        }
    }
}
