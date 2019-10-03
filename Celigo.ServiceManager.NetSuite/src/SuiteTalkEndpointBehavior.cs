using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Celigo.ServiceManager.NetSuite
{
    public class SuiteTalkEndpointBehavior : IEndpointBehavior
    {
        public SuiteTalkMessageInspector MessageInspector { get; }

        public SuiteTalkEndpointBehavior(SuiteTalkMessageInspector inspector)
        {
            MessageInspector = inspector;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(MessageInspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
