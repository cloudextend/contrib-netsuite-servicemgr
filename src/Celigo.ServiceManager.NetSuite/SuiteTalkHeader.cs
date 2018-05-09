using System.ServiceModel.Channels;

namespace Celigo.ServiceManager.NetSuite
{
    public abstract class SuiteTalkHeader: MessageHeader
    {
        public virtual bool IsApplicableTo(in Message message)
        {
            return true;
        }
    }
}
