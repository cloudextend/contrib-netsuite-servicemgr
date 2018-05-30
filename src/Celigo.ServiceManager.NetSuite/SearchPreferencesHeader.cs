using SuiteTalk;
using System.Diagnostics.Contracts;
using System.ServiceModel.Channels;
using System.Xml;

namespace Celigo.ServiceManager.NetSuite
{
    using Message = System.ServiceModel.Channels.Message;

    class SearchPreferencesHeader : SuiteTalkHeader
    {
        private readonly IPreferenceProvider _provider;

        public override string Name => "searchPreferences";

        public override string Namespace => SuiteTalkSchemas.Messages;

        public SearchPreferencesHeader(IPreferenceProvider provider)
        {
            _provider = provider;
        }

        public override bool IsApplicableTo(in Message message)
        {
            return message.Headers != null
                && message.Headers.Action != null
                && message.Headers.Action.StartsWith("search");
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            Contract.Requires(_provider != null);

            var searchPrefs = _provider.GetSearchPreferences();
            if (searchPrefs == null) return;

            void write<T>(string elementName, T value) {
                writer.WriteElementString(elementName, SuiteTalkSchemas.Messages, value.ToString());
            }

            if (searchPrefs.bodyFieldsOnly) write(nameof(searchPrefs.bodyFieldsOnly), searchPrefs.bodyFieldsOnly);
            if (searchPrefs.pageSizeSpecified) write(nameof(searchPrefs.pageSize), searchPrefs.pageSize);

            write(nameof(searchPrefs.returnSearchColumns), searchPrefs.returnSearchColumns);
        }

    }
}
