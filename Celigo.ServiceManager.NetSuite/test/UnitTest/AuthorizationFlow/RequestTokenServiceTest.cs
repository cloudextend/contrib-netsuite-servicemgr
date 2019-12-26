using System;
using System.Collections.Generic;
using System.Text;
using Task = System.Threading.Tasks.Task;
using Xunit;
using Celigo.SuiteTalk.PassportProviders.EnvironmentVariables;
using Celigo.ServiceManager.NetSuite;
using FluentAssertions;
using Celigo.ServiceManager.NetSuite.TSA;
using FakeItEasy;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace Tests.Celigo.ServiceManager.NetSuite.AuthorizationFlow
{
    public class RequestTokenServiceTest
    {
        private readonly IRequestTokenService _flowHelper;
        private readonly string _account;

        public RequestTokenServiceTest()
        {
            _flowHelper = new RequestTokenService(
                new HttpClient(),
                Options.Create(new TokenServiceOptions {
                    ConsumerKey = Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__ConsumerKey"),
                    ConsumerSecret = Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__ConsumerSecret"),
                    CallbackUrl = "https://localhost:5001/authorize"
                })
           ); 

            _account = Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__Account");
        }

        [Fact]
        public async Task Can_retrieve_the_Request_Token()
        {
            var response = await _flowHelper.GetRequestToken(_account);
            response.Should().NotBeNull();
            response.Error.Should().BeNull();
        }
    }
}
