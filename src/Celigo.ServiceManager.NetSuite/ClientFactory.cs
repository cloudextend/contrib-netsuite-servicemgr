using SuiteTalk;
using System.ServiceModel;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory
    {
        string ApplicationId { get; set; }

        INetSuiteClient CreateClient();

        INetSuiteClient CreateClient(IPassportProvider passportProvider);

        INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider);
    }

    public class ClientFactory : INetSuiteClientFactory
    {
        public string ApplicationId { get; set; }

        private static string relativeWsPath;

        static ClientFactory()
        {
            var endpoint = NetSuitePortTypeClient.GetDefaultEndpoint();
            relativeWsPath = endpoint.Uri.LocalPath;
        }
        
        public ClientFactory(string appId)
        {
            this.ApplicationId = appId;
        }

        public INetSuiteClient CreateClient() => this.CreateClient(null, null);

        public INetSuiteClient CreateClient(IPassportProvider passportProvider) => this.CreateClient(passportProvider, null);

        public INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider)
        {
            var client = new NetSuitePortTypeClient();

            if (configProvider != null && configProvider.DataCenter != null)
            {
                client.Endpoint.Address = GetDataCenterEndpoint(configProvider.DataCenter.DataCenterDomain);
            }

            var inspector = new SuiteTalkMessageInspector(new SuiteTalkHeader[] {
                new ApplicationInfoHeader(this.ApplicationId),
                new PassportHeader(passportProvider ?? client),
                new SearchPreferencesHeader(client)
            });

            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);
                        
            return client;
        }

        private EndpointAddress GetDataCenterEndpoint(string dataCenter)
        {
            if (dataCenter.EndsWith("/"))
            {
                return new EndpointAddress(dataCenter + ClientFactory.relativeWsPath);
            }
            else
            {
                return new EndpointAddress(string.Concat(dataCenter, "/", ClientFactory.relativeWsPath));
            }
        }
    }
}
