using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Celigo.ServiceManager.NetSuite.REST
{
    public struct Passport
    {
        public string Account { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }

        public string RoleId { get; set; }
    }
    
    public interface IRestletClient
    {
        Task<HttpResponseMessage> Get(
            in string account, 
            in string token, 
            in string tokenSecret, 
            IReadOnlyDictionary<string, string> queryParams = null
        );
        
        Task<HttpResponseMessage> Post<T>(
            in string account, 
            in string token, 
            in string tokenSecret, 
            in T message, 
            IReadOnlyDictionary<string, string> queryParams = null
        );
        
        Task<HttpResponseMessage> Get(
            in Passport passport, 
            IReadOnlyDictionary<string, string> queryParams = null
        );
        
        Task<HttpResponseMessage> Post<T>(
            in Passport passport, 
            in T message, 
            IReadOnlyDictionary<string, string> queryParams = null
        );
        
        [Obsolete]
        Task<HttpResponseMessage> Get(
            in string account, 
            in string token, 
            in string tokenSecret, 
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        );
        [Obsolete]
        Task<HttpResponseMessage> Get(
            in Passport passport, 
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        );
        [Obsolete]
        Task<HttpResponseMessage> Post<T>(
            in string account, 
            in string token, 
            in string tokenSecret, 
            in T message, 
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        );
        [Obsolete]
        Task<HttpResponseMessage> Post<T>(
            in Passport passport, 
            in T message, 
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        );
    }

    public class RestletClient: RestClient, IRestletClient
    {
        private static readonly HttpContent _emptyContent = new StringContent("", Encoding.UTF8, "application/json");

        private readonly RestletConfig _restlet;
        
        private const string _restletRelativePath = ".restlets.api.netsuite.com/app/site/hosting/restlet.nl";
        private const string _scriptParamName = "script";
        private const string _deployParamName = "deploy";

        public RestletClient(HttpClient httpClient, IOptions<RestClientOptions> options, IOptions<RestletConfig> restlet)
            : base(httpClient, options) 
        {
             _ = restlet.Value.Deploy ??
                throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.Deploy)}");
            _ = restlet.Value.Script ??
                throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.Script)}");
            
            _restlet = restlet.Value;       
        }

        public Task<HttpResponseMessage> Get(in string account, 
                                             in string token, 
                                             in string tokenSecret, 
                                             IReadOnlyDictionary<string, string> queryParams = null)
        {
            var urlBuilder = this.CreateUrlBuilder(account);
            string authHeader = this.GetTbaAuthHeader("GET", account, token, tokenSecret, urlBuilder.ToString(), queryParams);

            var requestUrl = this.CreateRequestUrl(urlBuilder, queryParams);
            return this.SendRequest(HttpMethod.Get, requestUrl, authHeader, _emptyContent);
        }
        
        public Task<HttpResponseMessage> Post<T>(
            in string account,
            in string token,
            in string tokenSecret,
            in T message,
            IReadOnlyDictionary<string, string> queryParams = null)
        {
            var urlBuilder = this.CreateUrlBuilder(account);
            string authHeader = this.GetTbaAuthHeader("POST", account, token, tokenSecret, urlBuilder.ToString(), queryParams);

            var requestUrl = this.CreateRequestUrl(urlBuilder, queryParams);
            return this.SendRequest(HttpMethod.Post, requestUrl, authHeader, CreateJsonMessageContent(message));
        }
        
        
        public Task<HttpResponseMessage> Get(
            in Passport passport, 
            IReadOnlyDictionary<string, string> queryParams = null
        )
        {
            ValidateBasicCreds(passport);

            string authHeader = this.GetBasicAuthHeaderValue(passport);
            Uri requestUrl = this.CreateRequestUrl(this.CreateUrlBuilder(passport.Account), queryParams);
            
            return this.SendRequest(HttpMethod.Get, requestUrl, authHeader, _emptyContent);
        }

        public Task<HttpResponseMessage> Post<T>(
            in Passport passport,
            in T message, 
            IReadOnlyDictionary<string, string> queryParams
        )
        {
            ValidateBasicCreds(passport);

            string authHeader = this.GetBasicAuthHeaderValue(passport);
            Uri requestUrl = this.CreateRequestUrl(this.CreateUrlBuilder(passport.Account), queryParams);
            
            return this.SendRequest(HttpMethod.Post, requestUrl, authHeader, CreateJsonMessageContent(message));
        }

        [Obsolete]
        public Task<HttpResponseMessage> Get(
            in string account,
            in string token,
            in string tokenSecret,
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(param => param.key, param => param.value);
            paramsMap[queryParam.key] = queryParam.value;
            return this.Get(account, token, tokenSecret, paramsMap);
        }

        [Obsolete]
        public Task<HttpResponseMessage> Get(
            in Passport passport,
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(param => param.key, param => param.value);
            paramsMap[queryParam.key] = queryParam.value;
            return this.Get(passport, paramsMap);
        }

        [Obsolete]
        public Task<HttpResponseMessage> Post<T>(
            in string account,
            in string token,
            in string tokenSecret,
            in T message,
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(param => param.key, param => param.value);
            paramsMap[queryParam.key] = queryParam.value;
            return this.Post(account, token, tokenSecret, message, paramsMap);
        }

        [Obsolete]
        public Task<HttpResponseMessage> Post<T>(
            in Passport passport,
            in T message,
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(param => param.key, param => param.value);
            paramsMap[queryParam.key] = queryParam.value;
            return this.Post(passport, message, paramsMap);
        }

        private StringBuilder CreateUrlBuilder(string account) => new StringBuilder("https://")
                                                                    .Append(account.ToLowerInvariant().Replace('_', '-'))
                                                                    .Append(_restletRelativePath);

        private Uri CreateRequestUrl(StringBuilder urlBuilder, IReadOnlyDictionary<string, string> queryParams)
        {
            urlBuilder.Append("?script=")
                      .Append(_restlet.Script)
                      .Append("&deploy=")
                      .Append(_restlet.Deploy);

            foreach (var param in queryParams)   
            {
                urlBuilder.Append("&")
                          .Append(param.Key)
                          .Append("=")
                          .Append(param.Value);
            }
            
            return new Uri(urlBuilder.ToString());
        }

        private string GetBasicAuthHeaderValue(Passport passport) =>
            new StringBuilder(120)
                .Append("NLAuth nlauth_account=").Append(passport.Account).Append(", ")
                .Append("nlauth_email=").Append(WebUtility.UrlEncode(passport.Email)).Append(", ")
                .Append("nlauth_signature=").Append(Uri.EscapeDataString(passport.Password))
                .Append(passport.RoleId != null ? ", nlauth_role=" + passport.RoleId: "")
                .ToString();
        
        private string GetTbaAuthHeader(string httpMethod, 
                                         string account, 
                                         string key, 
                                         string secret,
                                         string baseUrl,
                                         IReadOnlyDictionary<string, string> queryParams)
        {
            var oauthParams = GetAllOauthParams(queryParams);
            return this.GetAuthorizationHeaderValue(account, baseUrl, oauthParams, key, secret, httpMethod);
        }

        private SortedDictionary<string, string> GetAllOauthParams(IReadOnlyDictionary<string, string> queryParams)
        {
            var oauthParams = this.GetCommonOAuthParameters();
            oauthParams.Add(_scriptParamName, _restlet.Script);
            oauthParams.Add(_deployParamName, _restlet.Deploy);
            foreach (var param in queryParams)
            {
                oauthParams.Add(param.Key, param.Value);
            }

            return oauthParams;
        }

        private void ValidateBasicCreds(in Passport passport)
        {
            _ = passport.Account ?? throw new ArgumentNullException($"{nameof(Passport)}.{nameof(Passport.Account)}");
            _ = passport.Email ?? throw new ArgumentNullException($"{nameof(Passport)}.{nameof(Passport.Email)}");
            _ = passport.Password ?? throw new ArgumentNullException($"{nameof(Passport)}.{nameof(Passport.Password)}");
        }
    }
}