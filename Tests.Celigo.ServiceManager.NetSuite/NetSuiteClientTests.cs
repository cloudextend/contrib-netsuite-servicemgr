using Celigo.ServiceManager.NetSuite;
using SuiteTalk;
using System;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite
{
    using Meta;

    public class NetSuiteClientTests
    {
        private readonly INetSuiteClient client;

        public NetSuiteClientTests()
        {
            var config = new TestConfiguration();
            var factory = new ClientFactory(config.ApplicationId);
            client = factory.CreateClient(config.PassportProvider);
        }

        [Fact]
        public async void Can_execute_a_parameterless_SuiteTalk_method()
        {
            
            var serverTimeResult = await client.getServerTimeAsync();
            Assert.True(serverTimeResult.status.isSuccess);
            Assert.Equal(DateTime.Now.Year, serverTimeResult.serverTime.Year);
        }

        [Fact]
        public async void Can_execute_a_parameterized_SuiteTalk_method()
        {
            var customizationResult = await client.getCustomizationIdAsync(new CustomizationType {
                getCustomizationType = GetCustomizationType.customRecordType,
                getCustomizationTypeSpecified = true
            }, false);
            Assert.True(customizationResult.status.isSuccess);
        }
    }
}
