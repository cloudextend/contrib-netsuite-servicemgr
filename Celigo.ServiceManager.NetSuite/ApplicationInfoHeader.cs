using SuiteTalk;
using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    public class ApplicationInfoHeader : MessageHeader
    {
        public string ApplicationId { get; set; }

        public override string Name => "applicationInfo";

        public override string Namespace => SuiteTalkSchemas.Messages;

        public ApplicationInfoHeader(string appId = null)
        {
            this.ApplicationId = appId;
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteElementString("applicationId", this.ApplicationId);
        }
    }
}
