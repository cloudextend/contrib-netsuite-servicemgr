using SuiteTalk;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory
    {
        INetSuiteClient CreateClient(TbaUserToken userToken, IConfigurationProvider configurationProvider = null);

        INetSuiteClient CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider = null);
    }
}
