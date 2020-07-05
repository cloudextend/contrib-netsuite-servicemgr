using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.REST
{
    public interface IRestletClientFactory
    {
        RestletClient CreateClient(string restletName);
    }

    public class RestletClientFactory : IRestletClientFactory
    {
        private readonly Dictionary<string, RestletConfig> _registry;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<RestClientOptions> _restClientOptions;

        public RestletClientFactory(IEnumerable<RestletConfig> configs, IHttpClientFactory clientFactory, IOptions<RestClientOptions> options)
        {
            _clientFactory = clientFactory;
            _registry = configs.ToDictionary(c => c.RestletName);
            _restClientOptions = options;
        }

        public RestletClient CreateClient(string restletName)
        {
            if (_registry.TryGetValue(restletName, out var restlet))
            {
                var httpClient = _clientFactory.CreateClient(restletName);
                return new RestletClient(httpClient, _restClientOptions, restlet);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(restletName), $"A RESTlet named {restletName} has not been registered.");
            }
        }
    }
}
