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
        PartnerInfo partnerInfo { get; set; }

        string SuiteTalkVersion { get; }

        ServiceEndpoint Endpoint { get; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public partial class NetSuitePortTypeClient: INetSuiteClient
    {
        public ApplicationInfo applicationInfo { get; set; }
        public Passport passport { get; set; }
        public TokenPassport tokenPassport { get; set; }
        public Preferences preferences { get; set; }
        public PartnerInfo partnerInfo { get; set; }

        public string SuiteTalkVersion { get { return "2017.2"; } }
        
        public static System.ServiceModel.EndpointAddress GetDefaultEndpoint()
        {
            return GetDefaultEndpointAddress();
        }
    }
}