using SuiteTalk;
using System.ServiceModel.Channels;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory
    {
        string ApplicationId { get; set; }

        INetSuiteClient CreateClient(IPassportProvider passportProvider);
    }

    public class ClientFactory : INetSuiteClientFactory
    {
        public string ApplicationId { get; set; }


        public ClientFactory(string appId)
        {
            this.ApplicationId = appId;
        }
        
        public INetSuiteClient CreateClient(IPassportProvider passportProvider)
        {
            var client = new NetSuitePortTypeClient();
            var inspector = new SuiteTalkMessageInspector(new MessageHeader[] {
                new ApplicationInfoHeader(this.ApplicationId),
                new PassportHeader(passportProvider)
            });
            var endpointBehavior = new SuiteTalkEndpointBehavior(inspector);
            client.Endpoint.EndpointBehaviors.Add(endpointBehavior);


            return client;
        }
    }
}
