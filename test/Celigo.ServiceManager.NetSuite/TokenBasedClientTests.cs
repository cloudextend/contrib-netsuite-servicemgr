using Celigo.ServiceManager.NetSuite;
using FluentAssertions;
using SuiteTalk;
using System;
using System.ServiceModel;
using Tests.Celigo.ServiceManager.NetSuite.Meta;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite
{
    public class TokenBasedClientTests
    {
        private readonly INetSuiteClient client;

        public TokenBasedClientTests()
        {
            var testConfig = new TestConfiguration();
            var clientFactory = new ClientFactory(testConfig.ApplicationId);

            this.client = clientFactory.CreateClient(testConfig.TokenPassportProvider);
            var binding = (BasicHttpBinding)this.client.Endpoint.Binding;
        }

        [Fact]
        public async void Can_execute_a_parameterless_SuiteTalk_method()
        {
            var serverTimeResult = await client.getServerTimeAsync();
            serverTimeResult.status.isSuccess.Should().BeTrue();
            serverTimeResult.serverTime.Year.Should().Be(DateTime.Now.Year);
        }
    }
}
