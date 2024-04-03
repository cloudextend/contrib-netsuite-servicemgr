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
        IRestletClient CreateClient(string restletName);
    }

    public class RestletClientFactory : IRestletClientFactory
    {
        private readonly Dictionary<string, RestletConfig> _registry;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<RestClientOptions> _restClientOptions;

        public RestletClientFactory(IHttpClientFactory clientFactory, IOptions<RestletConfigOptions> configOptions, IOptions<RestClientOptions> options)
        {
            _clientFactory = clientFactory;

            var restlets = configOptions.Value?.Restlets ?? throw new InvalidOperationException("At least one RESTlet must be configured.");

            if (restlets.Any(r => r.Deploy == null || r.Script == null || r.RestletName == null))
            {
                throw new InvalidOperationException("At least one RESTlet has not been properly configured.");
            }

            _registry = configOptions.Value.Restlets.ToDictionary(c => c.RestletName);
            _restClientOptions = options;
        }

        public IRestletClient CreateClient(string restletName)
        {
            if (_registry.TryGetValue(restletName, out var restlet))
            {
                var httpClient = _clientFactory.CreateClient(restletName);
                httpClient.Timeout = TimeSpan.FromMinutes(restlet.HttpTimeoutInMinutes ?? 2);

                return new RestletClient(httpClient, _restClientOptions, Options.Create(restlet));
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(restletName), $"A RESTlet named {restletName} has not been registered.");
            }
        }

        public IRestletProxy CreateClient(string restletName, string account, string token, string tokenSecret) =>
            new TbaRestletProxy(account, token, tokenSecret, CreateClient(restletName));

        public IRestletProxy CreateClient(string restletName, Passport passport) =>
            new BasicCredsRestletProxy(passport, CreateClient(restletName));
    }
}
