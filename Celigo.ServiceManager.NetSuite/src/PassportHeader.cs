using SuiteTalk;
using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    public class PassportHeader : SuiteTalkHeader
    {
        private readonly IPassportProvider _basicPassportProvider;

        public override string Namespace => SuiteTalkSchemas.Messages;

        public override string Name { get; } = "passport";

        public PassportHeader(IPassportProvider provider)
        {
            _basicPassportProvider = provider;
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            if (_basicPassportProvider == null) throw new InvalidOperationException("The PassportProvider has not been set.");

            var credentials = _basicPassportProvider.GetPassport();

            if (credentials == null) throw new InvalidOperationException("The Credentials Provider provided null credentials");

            writer.WriteElementString(nameof(credentials.email), SuiteTalkSchemas.Core, credentials.email);
            writer.WriteElementString(nameof(credentials.password), SuiteTalkSchemas.Core, credentials.password);
            writer.WriteElementString(nameof(credentials.account), SuiteTalkSchemas.Core, credentials.account);
            if (credentials.role != null)
            {
                writer.WriteStartElement(nameof(credentials.role), SuiteTalkSchemas.Core);
                writer.WriteElementString(nameof(credentials.role.internalId), credentials.role.internalId);
                writer.WriteEndElement();
            }
        }
    }
}
