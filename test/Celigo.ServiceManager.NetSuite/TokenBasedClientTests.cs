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
        private readonly INetSuiteClient _client;

        public TokenBasedClientTests()
        {
            var testConfig = new TestConfiguration();
            var clientFactory = new ClientFactory(testConfig.ApplicationId);

            _client = clientFactory.CreateClient(testConfig.TokenPassportProvider);
            var binding = (BasicHttpBinding)_client.Endpoint.Binding;
        }

        [Fact]
        public async void Can_execute_a_parameterless_SuiteTalk_method()
        {
            var serverTimeResult = await _client.getServerTimeAsync();
            serverTimeResult.status.isSuccess.Should().BeTrue();
            serverTimeResult.serverTime.Year.Should().Be(DateTime.Now.Year);
        }
    }
}
