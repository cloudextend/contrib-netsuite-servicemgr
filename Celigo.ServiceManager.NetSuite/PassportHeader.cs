using SuiteTalk;
using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    public class PassportHeader : SuiteTalkHeader
    {
        private readonly IPassportProvider _provider;

        public override string Name => "passport";

        public override string Namespace => SuiteTalkSchemas.Messages;

        public PassportHeader(IPassportProvider provider)
        {
            _provider = provider;
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            var credentials = _provider.GetPassport();

            if (credentials == null) throw new InvalidOperationException("The Credentials Provider provided null credentials");

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
