using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Celigo.ServiceManager.NetSuite
{
    class SuiteTalkEndpointBehavior : IEndpointBehavior
    {
        private readonly SuiteTalkMessageInspector inspector;

        public SuiteTalkEndpointBehavior(SuiteTalkMessageInspector inspector)
        {
            this.inspector = inspector;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(this.inspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
