using SuiteTalk;
using System.Collections.Generic;

namespace Celigo.ServiceManager.NetSuite
{

    public class ClientFactory : ClientFactory<NetSuitePortTypeClient>
    {
        public ClientFactory(string appId): base(appId) { }
    }

    public class ClientFactory<T> : ClientFactoryBase<T>, INetSuiteClientFactory where T : class, INetSuiteClient, new()
    {
        private readonly string _appId;

        private readonly ITokenPassportBuilder _passportBuilder;

        public ClientFactory(string appId) : this(appId, null) { }

        public ClientFactory(string appId, IEnumerable<IDynamicEndpointBehavior> dynamicEndpointBehaviours)
            : this(new ClientFactoryOptions { ApplicationId = appId, Name = "DefaultFactory" }, dynamicEndpointBehaviours) { }

        public ClientFactory(ClientFactoryOptions options, IEnumerable<IDynamicEndpointBehavior> dynamicEndpointBehaviors): base(dynamicEndpointBehaviors)
        {
            _appId = options.ApplicationId;
            _passportBuilder = options.ConsumerKey != null && options.ConsumerSecret != null
                                ? new DefaultTokenPassportBuilder(options.ConsumerKey, options.ConsumerSecret)
                                : null;
        }

        public T CreateClient(Passport passport, IConfigurationProvider configurationProvider = null)
        {
            var client = new T { passport = passport };
            return this.ConfigureClient(client, _appId, client, configProvider: configurationProvider);
        }
        
        public T CreateClient(TbaUserToken userToken, IConfigurationProvider configurationProvider = null)
        {
            var tokenPassportProvider = new DefaultTokenPassportManager(_passportBuilder, userToken);
            return this.CreateClient(tokenPassportProvider, configurationProvider);
        }

        public T CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider = null) => 
            this.CreateClient(_appId, passportProvider, configProvider);

        
        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(Passport passport, IConfigurationProvider configurationProvider) => 
                this.CreateClient(passport, configurationProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(TbaUserToken userToken, IConfigurationProvider configurationProvider) => 
                this.CreateClient(userToken, configurationProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(IPassportProvider passportProvider, IConfigurationProvider configProvider) => 
                this.CreateClient(passportProvider, configProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider) => 
                this.CreateClient(passportProvider, configProvider);
    }
}
