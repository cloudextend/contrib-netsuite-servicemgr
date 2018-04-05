using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Celigo.ServiceManager.NetSuite
{
    public class SuiteTalkMessageInspector : IClientMessageInspector
    {
        private readonly SuiteTalkHeader[] headers;

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            for (int i = this.headers.Length - 1; i >= 0; i--)
            {
                if (this.headers[i].IsApplicableTo(request)) request.Headers.Add(this.headers[i]);
            }
            return null;
        }

        public SuiteTalkMessageInspector(SuiteTalkHeader[] headers)
        {
            this.headers = headers;
        }
    }
}
