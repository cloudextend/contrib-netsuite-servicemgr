using SuiteTalk;

namespace Celigo.ServiceManager.NetSuite
{
    public interface INetSuiteClientFactory
    {
        INetSuiteClient CreateClient(Passport passport, IConfigurationProvider configurationProvider = null);

        INetSuiteClient CreateClient(TbaUserToken userToken, IConfigurationProvider configurationProvider = null);

        INetSuiteClient CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider = null);

        INetSuiteClient CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider = null);
    }
}
