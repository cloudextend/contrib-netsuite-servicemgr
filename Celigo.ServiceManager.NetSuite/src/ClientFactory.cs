using SuiteTalk;
using System.Collections.Generic;

namespace Celigo.ServiceManager.NetSuite
{

    public class ClientFactory : ClientFactory<NetSuitePortTypeClient>
    {
        public ClientFactory(string appId): base(appId) { }
        public ClientFactory(ClientFactoryOptions options, IEnumerable<IDynamicEndpointBehavior> dynamicEndpointBehaviors) : base(options, dynamicEndpointBehaviors) { }
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
        
        public T CreateClient(TbaUserToken userToken, IConfigurationProvider configurationProvider = null)
        {
            var tokenPassportProvider = new DefaultTokenPassportManager(_passportBuilder, userToken);
            return this.CreateClient(tokenPassportProvider, configurationProvider);
        }
        
        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(TbaUserToken userToken, IConfigurationProvider configurationProvider) => 
                this.CreateClient(userToken, configurationProvider);

        INetSuiteClient 
            INetSuiteClientFactory.CreateClient(ITokenPassportProvider passportProvider, IConfigurationProvider configProvider) => 
                this.CreateClient(passportProvider, configProvider);
    }
}
