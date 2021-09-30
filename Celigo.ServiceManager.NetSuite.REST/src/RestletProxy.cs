using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Celigo.ServiceManager.NetSuite.REST
{
    public interface IRestletProxy
    {
        Task<HttpResponseMessage> Get(IReadOnlyDictionary<string, string> queryParams = null);
        
        Task<HttpResponseMessage> Post<T>(T data, IReadOnlyDictionary<string, string> queryParams = null);
        
        [Obsolete]
        Task<HttpResponseMessage> Get(
            (string key, string value) queryParam, 
            params (string key, string value)[] additionalQueryParams
        );
        
        [Obsolete]
        Task<HttpResponseMessage> Post<T>(
            T data, 
            (string key, string value) queryParam, 
            params (string key, string value)[] additionalQueryParams
        );
    }

    public class TbaRestletProxy : IRestletProxy
    {
        private readonly string _account;
        private readonly string _token;
        private readonly string _tokenSecret;
        private readonly IRestletClient _client;

        public TbaRestletProxy(string account, string token, string tokenSecret, IRestletClient client)
        {
            _account = account;
            _token = token;
            _tokenSecret = tokenSecret;
            _client = client;
        }

        public Task<HttpResponseMessage> Get(
            IReadOnlyDictionary<string, string> queryParams = null
        ) => this._client.Get(_account, _token, _tokenSecret, queryParams);

        public Task<HttpResponseMessage> Post<T>(
            T data, 
            IReadOnlyDictionary<string, string> queryParams
        ) => this._client.Post(_account, _token, _tokenSecret, data, queryParams);

        [Obsolete]
        public Task<HttpResponseMessage> Get(
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(q => q.key, q => q.value);
            return this._client.Get(_account, _token, _tokenSecret, paramsMap);
        }

        public Task<HttpResponseMessage> Post<T>(
            T data,
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(q => q.key, q => q.value);
            return this._client.Post(_account, _token, _tokenSecret, data, paramsMap);
        }
    }
    
    public struct BasicCredsRestletProxy : IRestletProxy
    {
        private readonly Passport _passport;
        private readonly IRestletClient _client;

        public BasicCredsRestletProxy(Passport passport, IRestletClient client)
        {
            _passport = passport;
            _client = client;
        }

        public Task<HttpResponseMessage> Get(
            IReadOnlyDictionary<string, string> queryParams = null
        ) => this._client.Get(_passport, queryParams);

        public Task<HttpResponseMessage> Post<T>(
            T data, 
            IReadOnlyDictionary<string, string> queryParams
        ) => this._client.Post(_passport, data, queryParams);

        [Obsolete]
        public Task<HttpResponseMessage> Get(
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(q => q.key, q => q.value);
            return this._client.Get(_passport, paramsMap);
        }

        public Task<HttpResponseMessage> Post<T>(
            T data,
            (string key, string value) queryParam,
            params (string key, string value)[] queryParams
        )
        {
            var paramsMap = queryParams.ToDictionary(q => q.key, q => q.value);
            return this._client.Post(_passport, data, paramsMap);
        }
    }
}