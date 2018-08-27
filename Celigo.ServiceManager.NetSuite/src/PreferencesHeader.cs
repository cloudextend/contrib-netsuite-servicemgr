using System.ServiceModel.Channels;
using System.Xml;
using SuiteTalk;

namespace Celigo.ServiceManager.NetSuite
{
    class PreferencesHeader: SuiteTalkHeader
    {
        public override string Name => "preferences";

        public override string Namespace => SuiteTalkSchemas.Messages;

        public override bool IsApplicableTo(System.ServiceModel.Channels.Message message)
        {
            return message.Headers != null
                && message.Headers.Action != null
                && !message.Headers.Action.StartsWith("search");
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
        }
    }
}
