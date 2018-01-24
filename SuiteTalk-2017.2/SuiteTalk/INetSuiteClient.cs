namespace SuiteTalk
{
    public partial interface INetSuiteClient: NetSuitePortType
    {
    }

    public partial class NetSuitePortTypeClient: INetSuiteClient
    {
        public static System.ServiceModel.EndpointAddress GetDefaultEndpoint()
        {
            return GetDefaultEndpointAddress();
        }
    }
}