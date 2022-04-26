using SuiteTalk;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Celigo.ServiceManager.NetSuite
{
    public class ClientFactoryBase<T> where T : class, INetSuiteClient, new()
    {
        private readonly IEnumerable<IDynamicEndpointBehavior> _dynamicEndpointBehaviors;

        public Action<T> ClientInitializer { get; set; }

        public ClientFactoryBase() : this(null) { }

        public ClientFactoryBase(IEnumerable<IDynamicEndpointBehavior> dynamicEndpointBehaviors)
        {
            _dynamicEndpointBehaviors = dynamicEndpointBehaviors;
        }

        private void AddDynamicEndpointBehaviours(T client)
        {
            if (_dynamicEndpointBehaviors == null) return;

            foreach (IDynamicEndpointBehavior depb in _dynamicEndpointBehaviors)
            {
                if (depb.IsEnabled())
                {
                    client.Endpoint.EndpointBehaviors.Add(depb);
                }
            }
        }

        public T CreateClient(ITokenPassportProvider tokenPassportProvider, IConfigurationProvider configProvider = null) =>
            this.ConfigureClient(
                new T(),
                tokenPassportProvider,
                configProvider
            );

        protected T ConfigureClient(
                T client,
                ITokenPassportProvider tokenPassportProvider,
                IConfigurationProvider configProvider = null
            )
        {
            string account = this.GetAccountNumber(tokenPassportProvider: tokenPassportProvider)
                    ?? throw new InvalidOperationException("An Account number was not provided to be used with basic credentials.");

            this.AddEndpointBehaviors(client, tokenPassportProvider);

            return ConfigureClient(client, account, configProvider);
        }

        protected T ConfigureClient(T client, string account, IConfigurationProvider configProvider)
        {
            // Increase binding timeout.
            client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);

            if (configProvider?.DataCenter != null)
            {
                client.Endpoint.Address = GetDataCenterEndpoint(configProvider.DataCenter.DataCenterDomain);
            }
            else
            {
                string subdomain = account.ToLowerInvariant().Replace("_", "-");
                client.Endpoint.Address = GetDataCenterEndpoint($"https://{subdomain}.suitetalk.api.netsuite.com");
            }

            this.AddDynamicEndpointBehaviours(client);

            this.ClientInitializer?.Invoke(client);
            return client;
        }


        private string GetAccountNumber(ITokenPassportProvider tokenPassportProvider = null)
        {
            return tokenPassportProvider?.GetTokenPassport()?.account;
        }

        private EndpointAddress GetDataCenterEndpoint(string dataCenter)
        {
            var endpoint = NetSuitePortTypeClient.GetDefaultEndpoint();
            var relativeWsPath = endpoint.Uri.LocalPath;

            if (!dataCenter.EndsWith("/"))
            {
                return new EndpointAddress(dataCenter + relativeWsPath);
            }
            else
            {
                return new EndpointAddress(
                    string.Concat(dataCenter.Substring(0, dataCenter.Length - 1), relativeWsPath)
                );
            }
        }
        protected void AddEndpointBehaviors(T client, ITokenPassportProvider tokenPassportProvider)
        {
            if (client.tokenPassport == null && tokenPassportProvider == null)
            {
                throw new InvalidOperationException("A Token Passport was not provided and no provider was specified.");
            }

            SuiteTalkHeader[] headers;

            if (client.tokenPassport != null)
            {
                headers = new SuiteTalkHeader[] { new SearchPreferencesHeader(client) };
            }
            else
            {
                headers = new SuiteTalkHeader[] {
                    new TokenPassportHeader(tokenPassportProvider),
                    new SearchPreferencesHeader(client)
                };
            }

            var inspector = new SuiteTalkMessageInspector(headers);

            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);

            this.AddDynamicEndpointBehaviours(client);
        }
    }
}
