using System.ServiceModel.Description;

namespace SuiteTalk
{
    public partial interface INetSuiteClient : NetSuitePortType
    {
#pragma warning disable IDE1006 // Naming Styles
        ApplicationInfo applicationInfo { get; set; }
        Passport passport { get; set; }
        TokenPassport tokenPassport { get; set; }
        Preferences preferences { get; set; }
        SearchPreferences searchPreferences { get; set; }
        PartnerInfo partnerInfo { get; set; }

        string SuiteTalkVersion { get; }

        ServiceEndpoint Endpoint { get; }

        System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchAsync(SearchRecord searchRecord, SearchPreferences searchPreferences);
#pragma warning restore IDE1006 // Naming Styles

    }

    public partial class NetSuitePortTypeClient : INetSuiteClient
    {
        public ApplicationInfo applicationInfo { get; set; }
        public Passport passport { get; set; }
        public TokenPassport tokenPassport { get; set; }
        public Preferences preferences { get; set; }
        public SearchPreferences searchPreferences { get; set; }
        public PartnerInfo partnerInfo { get; set; }

        public string SuiteTalkVersion { get { return "2017.2"; } }

        public static System.ServiceModel.EndpointAddress GetDefaultEndpoint()
        {
            return GetDefaultEndpointAddress();
        }

        public async System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchAsync(SearchRecord searchRecord, SearchPreferences searchPreferences)
        {
            var originalPreferences = this.searchPreferences;
            this.searchPreferences = searchPreferences;
            var result = await this.searchAsync(searchRecord);
            this.searchPreferences = originalPreferences;

            return result;
        }
    }
}