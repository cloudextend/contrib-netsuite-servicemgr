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

    public class ClientFactory<T>: INetSuiteClientFactory where T: class, INetSuiteClient, new()
    {
        public string ApplicationId { get; set; }

        public Action<T> ClientInitializer { get; set; }
        string INetSuiteClientFactory.ApplicationId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
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

        public T CreateClient(IPassportProvider passportProvider) => this.CreateClient(passportProvider, null);

        public T CreateClient(ITokenPassportProvider tokenPassportProvider) => this.CreateClient(tokenPassportProvider, null);

        public T CreateClient(ITokenPassportProvider tokenPassportProvider, IConfigurationProvider configProvider) => this.ConfigureClient(
                new T(), 
                tokenPassportProvider: tokenPassportProvider,
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

            if (client.tokenPassport != null)
            {
                headers = new SuiteTalkHeader[] { new SearchPreferencesHeader(client) };
            }
            else if (client.passport != null)
            {
                headers = new SuiteTalkHeader[] {
                    new ApplicationInfoHeader(this.ApplicationId),
                    new SearchPreferencesHeader(client)
                };
            }
            else if (tokenPassportProvider != null)
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
                    new PassportHeader(passportProvider),
                    new SearchPreferencesHeader(client)
                };
            }
            var inspector = new SuiteTalkMessageInspector(headers);

            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);

            if (this.ClientInitializer != null)
            {
                this.ClientInitializer(client);
                return client;
            }
            else
            {
                return client;
            }
        }


        private EndpointAddress GetDataCenterEndpoint(string dataCenter)
        {
            var endpoint = NetSuitePortTypeClient.GetDefaultEndpoint();
            var relativeWsPath = endpoint.Uri.LocalPath;

            if (dataCenter.EndsWith("/"))
            {
                return new EndpointAddress(dataCenter + relativeWsPath);
            }
            else
            {
                return new EndpointAddress(string.Concat(dataCenter, "/", relativeWsPath));
            }
        }

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient() => this.CreateClient();

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(Passport passport) => this.CreateClient(passport);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(Passport passport, IConfigurationProvider configurationProvider) => 
                this.CreateClient(passport, configurationProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(IPassportProvider passportProvider) => this.CreateClient(passportProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider) => 
                this.CreateClient(passportProvider, configProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(ITokenPassportProvider passportProvider) => this.CreateClient(passportProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider) => 
                this.CreateClient(passportProvider, configProvider);
    }
}
