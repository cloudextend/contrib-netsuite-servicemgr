using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Celigo.ServiceManager.NetSuite
{
    public class SuiteTalkMessageInspector : IClientMessageInspector
    {
        private readonly MessageHeader[] headers;

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            for (int i = this.headers.Length - 1; i >= 0; i--)
            {
                request.Headers.Add(this.headers[i]);
            }
            return null;
        }

        public SuiteTalkMessageInspector(MessageHeader[] headers)
        {
            this.headers = headers;
        }
    }
}
