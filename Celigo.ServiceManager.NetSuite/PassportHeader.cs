using SuiteTalk;
using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    public class PassportHeader : SuiteTalkHeader
    {
        private readonly IPassportProvider provider;

        public override string Name => "passport";

        public override string Namespace => SuiteTalkSchemas.Messages;

        public PassportHeader(IPassportProvider provider)
        {
            this.provider = provider;
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            var credentials = this.provider.GetPassport();

            writer.WriteElementString("email", SuiteTalkSchemas.Core, credentials.email);
            writer.WriteElementString("password", SuiteTalkSchemas.Core, credentials.password);
            writer.WriteElementString("account", SuiteTalkSchemas.Core, credentials.account);
            if (credentials.role != null)
            {
                writer.WriteStartElement("role", SuiteTalkSchemas.Core);
                writer.WriteElementString("internalId", credentials.role.internalId);
                writer.WriteEndElement();
            }
        }
    }
}
