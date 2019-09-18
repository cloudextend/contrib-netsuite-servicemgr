using System;
using System.Collections.Generic;
using System.Text;
using Task = System.Threading.Tasks.Task;
using Xunit;
using Celigo.SuiteTalk.PassportProviders.EnvironmentVariables;
using Celigo.ServiceManager.NetSuite;
using FluentAssertions;
using Celigo.ServiceManager.NetSuite.TSA;

namespace Tests.Celigo.ServiceManager.NetSuite.AuthorizationFlow
{
    public class AuthorizationFlowHelperTests
    {
        private readonly TokenService _flowHelper;
        private readonly string _account;

        public AuthorizationFlowHelperTests()
        {
            _flowHelper = new DefaultTokenService(
                Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__ConsumerKey"),
                Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__ConsumerSecret")
           );

            _account = Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__Account");
        }

        [Fact]
        public async Task Can_retrieve_the_Request_Token()
        {
            var response = await _flowHelper.GetRequestToken(_account, "https://localhost:44369/");
            response.Should().NotBeNull();
            response.Error.Should().BeNull();

        }
    }
}
