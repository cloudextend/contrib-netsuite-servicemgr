using SuiteTalk;
using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    public class TokenPassportHeader: SuiteTalkHeader
    {
        private readonly ITokenPassportProvider _provider;

        public override string Namespace => SuiteTalkSchemas.Messages;

        public override string Name { get; } = "tokenPassport";

        public TokenPassportHeader(ITokenPassportProvider passportProvider)
        {
            _provider = passportProvider;
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            var tokenPassport = _provider.GetTokenPassport();

            if (tokenPassport == null) throw new InvalidOperationException("The Credentials Provider provided null credentials");

            writer.WriteElementString(nameof(tokenPassport.account), SuiteTalkSchemas.Core, tokenPassport.account);
            writer.WriteElementString(nameof(tokenPassport.consumerKey), SuiteTalkSchemas.Core, tokenPassport.consumerKey);
            writer.WriteElementString(nameof(tokenPassport.nonce), SuiteTalkSchemas.Core, tokenPassport.nonce);

            if (tokenPassport.signature != null)
            {
                writer.WriteStartElement(nameof(tokenPassport.signature), SuiteTalkSchemas.Core);
                writer.WriteAttributeString(nameof(tokenPassport.signature.algorithm), tokenPassport.signature.algorithm);
                writer.WriteValue(tokenPassport.signature.Value);
                writer.WriteEndElement();
            }

            writer.WriteElementString(nameof(tokenPassport.timestamp), SuiteTalkSchemas.Core, tokenPassport.timestamp.ToString());
            writer.WriteElementString(nameof(tokenPassport.token), SuiteTalkSchemas.Core, tokenPassport.token);
        }
    }
}
