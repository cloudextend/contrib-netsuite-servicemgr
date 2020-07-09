using System.Net.Http;
using System.Threading.Tasks;

namespace Celigo.ServiceManager.NetSuite.REST
{
    public interface IRestletProxy
    {
        Task<HttpResponseMessage> Get(params (string key, string value)[] queryParams);
        Task<HttpResponseMessage> Post<T>(T data, params (string key, string value)[] queryParams);
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

        public Task<HttpResponseMessage> Get(params (string key, string value)[] queryParams) =>
            this._client.Get(_account, _token, _tokenSecret, queryParams);

        public Task<HttpResponseMessage> Post<T>(T data, params (string key, string value)[] queryParams) =>
            this._client.Post(_account, _token, _tokenSecret, data, queryParams);
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

        public Task<HttpResponseMessage> Get(params (string key, string value)[] queryParams) =>
            this._client.Get(_passport, queryParams);

        public Task<HttpResponseMessage> Post<T>(T data, params (string key, string value)[] queryParams) =>
            this._client.Post(_passport, data, queryParams);
    }
}