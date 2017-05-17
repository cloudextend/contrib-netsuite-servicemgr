using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    public class PassportHeader : MessageHeader
    {
        public override string Name => "passport";

        public override string Namespace => SuiteTalkSchemas.Messages;

        public SuiteTalk.Passport Credentials { get; set; }

        public PassportHeader(SuiteTalk.Passport credentials = null)
        {
            this.Credentials = credentials;
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteElementString("email", SuiteTalkSchemas.Core, Credentials.email);
            writer.WriteElementString("password", SuiteTalkSchemas.Core, Credentials.password);
            writer.WriteElementString("account", SuiteTalkSchemas.Core, Credentials.account);
            if (Credentials.role != null)
            {
                writer.WriteStartElement("role", SuiteTalkSchemas.Core);
                writer.WriteElementString("internalId", Credentials.role.internalId);
                writer.WriteEndElement();
            }
        }
    }
}
