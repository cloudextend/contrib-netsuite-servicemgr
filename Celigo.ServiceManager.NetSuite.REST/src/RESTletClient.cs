using System;
using System.Collections.Generic;
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
        Task<HttpResponseMessage> Get(in string account, in string token, in string tokenSecret, params (string key, string value)[] queryParams);
        Task<HttpResponseMessage> Post<T>(in string account, in string token, in string tokenSecret, in T message, params (string key, string value)[] queryParams);
        
        Task<HttpResponseMessage> Get(in Passport passport, params (string key, string value)[] queryParams);
        Task<HttpResponseMessage> Post<T>(in Passport passport, in T message, params (string key, string value)[] queryParams);
    }

    public class RestletClient: RestClient, IRestletClient
    {
        private static readonly HttpContent _emptyContent = new StringContent("", Encoding.UTF8, "application/json");

        private readonly RestletConfig _restlet;
        
        private const string _restletRelativePath = ".restlets.api.netsuite.com/app/site/hosting/restlet.nl";
        private const string _scriptParamName = "script";
        private const string _deployParamName = "deploy";
        
        //public RestletClient(HttpClient httpClient, IOptions<RestClientOptions> options, RestletConfig restlet) 
        //    : base(httpClient, options)
        //{
        //    _ = restlet.Deploy ??
        //        throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.Deploy)}");
        //    _ = restlet.Script ??
        //        throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.Script)}");
            
        //    _restlet = restlet;
        //}

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
                                             params (string key, string value)[] queryParams)
        {
            var urlBuilder = this.CreateUrlBuilder(account);
            string authHeader = this.GetTbaAuthHeader("GET", account, token, tokenSecret, urlBuilder.ToString(), queryParams);

            var requestUrl = this.CreateRequestUrl(urlBuilder, queryParams);
            return this.SendRequest(HttpMethod.Get, requestUrl, authHeader, _emptyContent);
        }

        public Task<HttpResponseMessage> Post<T>(in string account, 
                                                 in string token, 
                                                 in string tokenSecret, 
                                                 in T message, 
                                                 params (string key, string value)[] queryParams)
        {
            var urlBuilder = this.CreateUrlBuilder(account);
            string authHeader = this.GetTbaAuthHeader("POST", account, token, tokenSecret, urlBuilder.ToString(), queryParams);

            var requestUrl = this.CreateRequestUrl(urlBuilder, queryParams);
            return this.SendRequest(HttpMethod.Post, requestUrl, authHeader, CreateJsonMessageContent(message));
        }

        public Task<HttpResponseMessage> Get(in Passport passport, 
                                             params (string key, string value)[] queryParams)
        {
            ValidateBasicCreds(passport);

            string authHeader = this.GetBasicAuthHeaderValue(passport);
            Uri requestUrl = this.CreateRequestUrl(this.CreateUrlBuilder(passport.Account), queryParams);
            
            return this.SendRequest(HttpMethod.Get, requestUrl, authHeader, _emptyContent);
        }

        public Task<HttpResponseMessage> Post<T>(in Passport passport,
                                                 in T message, 
                                                 params (string key, string value)[] queryParams)
        {
            ValidateBasicCreds(passport);

            string authHeader = this.GetBasicAuthHeaderValue(passport);
            Uri requestUrl = this.CreateRequestUrl(this.CreateUrlBuilder(passport.Account), queryParams);
            
            return this.SendRequest(HttpMethod.Post, requestUrl, authHeader, CreateJsonMessageContent(message));
        }

        private StringBuilder CreateUrlBuilder(string account) => new StringBuilder("https://")
                                                                    .Append(account.ToLowerInvariant().Replace('_', '-'))
                                                                    .Append(_restletRelativePath);

        private Uri CreateRequestUrl(StringBuilder urlBuilder, (string key, string value)[] queryParams)
        {
            urlBuilder
                .Append("?script=")
                .Append(_restlet.Script)
                .Append("&deploy=")
                .Append(_restlet.Deploy);

            for (int i = queryParams.Length - 1; i >= 0; i--)
            {
                urlBuilder.Append("&");
                urlBuilder.Append(queryParams[i].key);
                urlBuilder.Append("=");
                urlBuilder.Append(queryParams[i].value);
            }
            
            return new Uri(urlBuilder.ToString());
        }

        private string GetBasicAuthHeaderValue(Passport passport) =>
            new StringBuilder(120)
                .Append("NLAuth nlauth_account=").Append(passport.Account)
                .Append("nlauth_email=").Append(WebUtility.UrlEncode(passport.Email))
                .Append("nlauth_signature=").Append(Uri.EscapeDataString(passport.Password))
                .Append(passport.RoleId != null ? "nlauth_role=" + passport.RoleId: "")
                .ToString();
        
        private string GetTbaAuthHeader(string httpMethod, 
                                         string account, 
                                         string key, 
                                         string secret,
                                         string baseUrl,
                                         (string key, string value)[] queryParams)
        {
            var oauthParams = GetAllOauthParams(queryParams);
            return this.GetAuthorizationHeaderValue(account, baseUrl, oauthParams, key, secret, httpMethod);
        }

        private SortedDictionary<string, string> GetAllOauthParams((string key, string value)[] queryParams)
        {
            var oauthParams = this.GetCommonOAuthParameters();
            oauthParams.Add(_scriptParamName, _restlet.Script);
            oauthParams.Add(_deployParamName, _restlet.Deploy);
            for (int i = queryParams.Length - 1; i >= 0; i--)
            {
                oauthParams.Add(queryParams[i].key, queryParams[i].value);
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