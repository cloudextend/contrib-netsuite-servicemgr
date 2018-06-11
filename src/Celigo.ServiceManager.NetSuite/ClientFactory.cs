using SuiteTalk;
using System;
using System.ServiceModel;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory<T> where T: INetSuiteClient
    {
        string ApplicationId { get; set; }

        T CreateClient();

        T CreateClient(Passport passport);

        T CreateClient(Passport passport, IConfigurationProvider configurationProvider);

        T CreateClient(IPassportProvider passportProvider);

        T CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider);

        T CreateClient(ITokenPassportProvider passportProvider);

        T CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider);
    }

    public interface INetSuiteClientFactory: INetSuiteClientFactory<INetSuiteClient>{ }

    public class ClientFactory : ClientFactory<NetSuitePortTypeClient>
    {
        public ClientFactory(string appId): base(appId) { }
    }

    public class ClientFactory<T>: INetSuiteClientFactory<T>
        where T: INetSuiteClient, new()
    {
        public string ApplicationId { get; set; }

        public Func<T, T> ClientInitializer { get; set; }

        private static readonly string _relativeWsPath;

        static ClientFactory()
        {
            var endpoint = NetSuitePortTypeClient.GetDefaultEndpoint();
            _relativeWsPath = endpoint.Uri.LocalPath;
        }

        public ClientFactory(string appId)
        {
            this.ApplicationId = appId;
        }

        public T CreateClient()
        {
            var client = new T();
            return this.ConfigureClient(client);
        }

        public T CreateClient(Passport passport, IConfigurationProvider configurationProvider)
        {
            var client = new T { passport = passport };
            return this.ConfigureClient(client, configProvider: configurationProvider);
        }

        public T CreateClient(Passport passport) => this.CreateClient(passport, null);

        public T CreateClient(TokenPassport passport, IConfigurationProvider configurationProvider)
        {
            var client = new T { tokenPassport = passport };
            return this.ConfigureClient(
                client, 
                tokenPassportProvider: client,
                configProvider: configurationProvider
            );
        }

        public T CreateClient(TokenPassport passport) => this.CreateClient(passport, null);

        public T CreateClient(IPassportProvider passportProvider) => this.CreateClient(passportProvider, null);

        public T CreateClient(ITokenPassportProvider passportProvider) => this.CreateClient(passportProvider, null);

        public T CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider) => this.ConfigureClient(
                new T(), 
                tokenPassportProvider: passportProvider,
                configProvider: configProvider
            );

        public T CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider) => this.ConfigureClient(
                new T(), 
                passportProvider: passportProvider, 
                configProvider: configProvider
            );

        private T ConfigureClient(
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
