using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Celigo.ServiceManager.NetSuite.REST
{
    public interface IRestletClient
    {
        Task<HttpResponseMessage> Get(string account, string token, string tokenSecret, params (string key, string value)[] queryParams);
        Task<HttpResponseMessage> Post<T>(string account, string token, string tokenSecret, T message, params (string key, string value)[] queryParams);
    }

    public class RestletClient: RestClient, IRestletClient
    {
        private readonly RestletConfig _restlet;
        
        private const string _restletRelativePath = ".restlets.api.netsuite.com/app/site/hosting/restlet.nl?";
        private const string _scriptParamName = "script";
        private const string _deployParamName = "deploy";
        
        public RestletClient(HttpClient httpClient, IOptions<RestClientOptions> options, RestletConfig restlet) 
            : base(httpClient, options)
        {
            _ = restlet.Deploy ??
                throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.Deploy)}");
            _ = restlet.Script ??
                throw new ArgumentNullException($"{nameof(RestletConfig)}.{nameof(RestletConfig.Script)}");
            
            _restlet = restlet;
        }

        public RestletClient(HttpClient httpClient, IOptions<RestClientOptions> options, IOptions<RestletConfig> restlet)
            : this(httpClient, options, restlet.Value) { }

        public Task<HttpResponseMessage> Get(string account, string token, string tokenSecret, params (string key, string value)[] queryParams)
        {
            var (requestUrl, authHeader) = GenerateHeaderAndUrl(account, token, tokenSecret, queryParams);
            return this.SendRequest(HttpMethod.Get, requestUrl, authHeader);
        }

        public Task<HttpResponseMessage> Post<T>(string account, string token, string tokenSecret, T message, params (string key, string value)[] queryParams)
        {
            var (requestUrl, authHeader) = GenerateHeaderAndUrl(account, token, tokenSecret, queryParams);
            return this.SendRequest(HttpMethod.Post, requestUrl, authHeader, CreateJsonMessageContent(message));
        }
        
        private StringBuilder CreateUrlBuilder(string account) => new StringBuilder("https://")
                                                                .Append(account.ToLowerInvariant().Replace('_', '-'))
                                                                .Append(_restletRelativePath);

        private Uri CreateRequestUrl(StringBuilder urlBuilder, (string key, string value)[] queryParams)
        {
            urlBuilder
                .Append("script=")
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

        private (Uri requestUrl, string authHeader) GenerateHeaderAndUrl(string account, string token, string tokenSecret, (string key, string value)[] queryParams)
        {
            var urlBuilder = this.CreateUrlBuilder(account);

            var oauthParams = this.GetCommonOAuthParameters();
            oauthParams.Add(_scriptParamName, _restlet.Script);
            oauthParams.Add(_deployParamName, _restlet.Deploy);
            for (int i = queryParams.Length - 1; i >= 0; i--)
            {
                oauthParams.Add(queryParams[i].key, queryParams[i].value);
            }

            string authHeader = this.GetAuthorizationHeaderValue(account, urlBuilder.ToString(), oauthParams, token, tokenSecret, "GET");
            Uri requestUrl = this.CreateRequestUrl(urlBuilder, queryParams);
            return (requestUrl, authHeader);
        }
    }
}