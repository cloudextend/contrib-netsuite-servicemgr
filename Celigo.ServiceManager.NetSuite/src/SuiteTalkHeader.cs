using System.ServiceModel.Channels;

namespace Celigo.ServiceManager.NetSuite
{
    public abstract class SuiteTalkHeader: MessageHeader
    {
        public virtual bool IsApplicableTo(Message message)
        {
            return true;
        }
    }
}
