using SuiteTalk;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory
    {
        string ApplicationId { get; set; }

        INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider = null);
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
        
        public INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider = null)
        {
            var client = new NetSuitePortTypeClient();

            if (configProvider != null && configProvider.DataCenter != null)
            {
                client.Endpoint.Address = GetDataCenterEndpoint(configProvider.DataCenter.DataCenterDomain);
            }

            var inspector = new SuiteTalkMessageInspector(new MessageHeader[] {
                new ApplicationInfoHeader(this.ApplicationId),
                new PassportHeader(passportProvider)
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
