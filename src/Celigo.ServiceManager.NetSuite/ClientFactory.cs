using SuiteTalk;
using System;
using System.ServiceModel;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory
    {
        string ApplicationId { get; set; }

        INetSuiteClient CreateClient();

        INetSuiteClient CreateClient(Passport passport);

        INetSuiteClient CreateClient(Passport passport, IConfigurationProvider configurationProvider);

        INetSuiteClient CreateClient(IPassportProvider passportProvider);

        INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider);

        INetSuiteClient CreateClient(ITokenPassportProvider passportProvider);

        INetSuiteClient CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider);
    }

    public class ClientFactory : ClientFactory<NetSuitePortTypeClient>
    {
        public ClientFactory(string appId): base(appId) { }
    }

    public class ClientFactory<T>: INetSuiteClientFactory 
        where T: INetSuiteCompositeClient, new()
    {
        public string ApplicationId { get; set; }

        public Func<T, T> ClientInitializer { get; set; }

        private static readonly string _relativeWsPath;

        static ClientFactory()
        {
            var endpoint = NetSuitePortTypeClient.GetDefaultEndpoint();
            _relativeWsPath = endpoint.Uri.LocalPath;
        }

        public ClientFactory(string appId) {

            this.ApplicationId = appId;
        }

        public INetSuiteClient CreateClient()
        {
            var client = new T();
            return this.ConfigureClient(client);
        }

        public INetSuiteClient CreateClient(Passport passport, IConfigurationProvider configurationProvider)
        {
            var client = new T { passport = passport };
            return this.ConfigureClient(client, configProvider: configurationProvider);
        }

        public INetSuiteClient CreateClient(Passport passport) => this.CreateClient(passport);

        public INetSuiteClient CreateClient(IPassportProvider passportProvider) => this.CreateClient(passportProvider, null);

        public INetSuiteClient CreateClient(ITokenPassportProvider passportProvider) => this.CreateClient(passportProvider, null);

        public INetSuiteClient CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider) => this.ConfigureClient(
                new T(), 
                tokenPassportProvider: passportProvider,
                configProvider: configProvider
            );

        public INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider) => this.ConfigureClient(
                new T(), 
                passportProvider: passportProvider, 
                configProvider: configProvider
            );

        private INetSuiteClient ConfigureClient(
                T client,
                IPassportProvider passportProvider = null,
                ITokenPassportProvider tokenPassportProvider = null,
                IConfigurationProvider configProvider = null
            )
        {
            if (configProvider != null && configProvider.DataCenter != null)
            {
                client.Endpoint.Address = GetDataCenterEndpoint(configProvider.DataCenter.DataCenterDomain);
            }

            SuiteTalkHeader[] headers;

            if (tokenPassportProvider != null)
            {
                headers = new SuiteTalkHeader[] {
                    new TokenPassportHeader(tokenPassportProvider),
                    new SearchPreferencesHeader(client)
                };
            }
            else
            {
                headers = new SuiteTalkHeader[] {
                    new ApplicationInfoHeader(this.ApplicationId),
                    new PassportHeader(passportProvider ?? client),
                    new SearchPreferencesHeader(client)
                };
            }
            var inspector = new SuiteTalkMessageInspector(headers);

            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);

            if (this.ClientInitializer != null)
            {
                return this.ClientInitializer(client);
            }
            else
            {
                return client;
            }
        }


        private EndpointAddress GetDataCenterEndpoint(string dataCenter)
        {
            if (dataCenter.EndsWith("/"))
            {
                return new EndpointAddress(dataCenter + ClientFactory._relativeWsPath);
            }
            else
            {
                return new EndpointAddress(string.Concat(dataCenter, "/", ClientFactory._relativeWsPath));
            }
        }
    }
}
