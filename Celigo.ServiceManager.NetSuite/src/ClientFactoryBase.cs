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

        public T CreateClient(string applicationId, IPassportProvider passportProvider, IConfigurationProvider configProvider = null) => 
            this.ConfigureClient(
                new T(),
                applicationId,
                passportProvider,
                configProvider
            );

        protected T ConfigureClient(
                T client,
                string applicationId,
                IPassportProvider passportProvider,
                IConfigurationProvider configProvider = null
            )
        {
            if (applicationId == null) throw new InvalidOperationException("Application ID is required for use with basic credentials.");

            string account = this.GetAccountNumber(client, passportProvider)
                    ?? throw new InvalidOperationException("An Account number was not provided to be used with basic credentials.");

            this.AddEndpointBehaviors(client, applicationId, passportProvider);

            return ConfigureClient(client, account, configProvider);
        }

        protected T ConfigureClient(
                T client,
                ITokenPassportProvider tokenPassportProvider,
                IConfigurationProvider configProvider = null
            )
        {
            string account = this.GetAccountNumber(client, tokenPassportProvider: tokenPassportProvider)
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


        private string GetAccountNumber(T client, 
                                        IPassportProvider passportProvider = null, 
                                        ITokenPassportProvider tokenPassportProvider = null)
        {
            return client.passport?.account
                ?? tokenPassportProvider?.GetTokenPassport()?.account
                ?? passportProvider?.GetPassport()?.account;
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

        private void AddEndpointBehaviors(T client, string applicationId, IPassportProvider passportProvider)
        {
            if (applicationId == null) throw new InvalidOperationException("The Application ID was not specified.");
            if (client.passport == null && passportProvider == null) throw new InvalidOperationException("A Passport was not specified and no provider was given.");

            SuiteTalkHeader[] headers;

            if (client.passport != null)
            {
                headers = new SuiteTalkHeader[] {
                    new ApplicationInfoHeader(applicationId),
                    new SearchPreferencesHeader(client)
                };
            }
            else
            {
                headers = new SuiteTalkHeader[] {
                    new ApplicationInfoHeader(applicationId),
                    new PassportHeader(passportProvider),
                    new SearchPreferencesHeader(client)
                };
            }

            var inspector = new SuiteTalkMessageInspector(headers);

            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);

            this.AddDynamicEndpointBehaviours(client);
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
