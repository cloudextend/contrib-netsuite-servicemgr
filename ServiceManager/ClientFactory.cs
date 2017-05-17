using SuiteTalk;
using System.ServiceModel.Channels;

namespace Celigo.ServiceManager.NetSuite
{
    public interface IClientFactory
    {
        string ApplicationId { get; set; }

        INetSuiteClient CreateClient(Passport credentials);
    }

    public class ClientFactory : IClientFactory
    {
        public string ApplicationId { get; set; }

        public ClientFactory(string appId)
        {
            this.ApplicationId = appId;
        }
        
        public INetSuiteClient CreateClient(Passport credentials)
        {
            var client = new NetSuitePortTypeClient();

            var inspector = new SuiteTalkMessageInspector(new MessageHeader[] {
                new ApplicationInfoHeader(this.ApplicationId),
                new PassportHeader(credentials)
            });
            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);

            return client;
        }
    }
}
