using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Celigo.ServiceManager.NetSuite
{
    public class SuiteTalkMessageInspector : IClientMessageInspector
    {
        private readonly SuiteTalkHeader[] _headers;

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            for (int i = _headers.Length - 1; i >= 0; i--)
            {
                if (_headers[i].IsApplicableTo(request)) request.Headers.Add(_headers[i]);
            }
            return null;
        }

        public SuiteTalkMessageInspector(SuiteTalkHeader[] headers)
        {
            _headers = headers;
        }
    }
}
