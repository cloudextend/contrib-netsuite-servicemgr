using _.Utils;
using Celigo.ServiceManager.NetSuite.REST;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace _.Given_a_RestletClient
{
    public class When_computing_the_authorization_header: RestClientTestBase
    {
        private RestClient _client;
        private string _authParameter;
        private string _authScheme;

        [Fact]
        public async Task It_generates_the_correct_signature()
        {
            await When();

            _authParameter.Should().Contain("oauth_signature=\"QqWfhrLQOlRFKR69DqenrtLaCVWuSzKklotUVWD3I04%3D\"");
        }

        [Fact]
        public async Task It_includes_all_required_parameters()
        {
            await When();
            _authScheme = "OAuth";
            _authParameter.Should().Contain("realm=\"TSTDRV12345\"");
            _authParameter.Should().Contain("oauth_consumer_key=\"dpf43f3p2l4k3l03\"");
            _authParameter.Should().Contain("oauth_token=\"nnch734d00sl2jdk\"");
            _authParameter.Should().Contain("oauth_nonce=\"tUoTBMCLMiW\"");
            _authParameter.Should().Contain("oauth_timestamp=\"1594207766\"");
            _authParameter.Should().Contain("oauth_signature_method=\"HMAC-SHA256\"");
            _authParameter.Should().Contain("oauth_version=\"1.0\"");
        }

        [Fact]
        public async Task It_should_include_proper_account_for_sandbox()
        {
            A.CallTo(() => this.MessageHandler.SendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(callParams => {
                    var req = callParams.Arguments[0] as HttpRequestMessage;
                    _authScheme = req.Headers.Authorization.Scheme;
                    _authParameter = req.Headers.Authorization.Parameter;

                    return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
                });

            await _client.Get(
                "1234-sb1",
                new Uri("https://1234-sb1.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=custscript1&deploy=custdeploy1"),
                _token,
                _tokenSecret);
            _authParameter.Should().Contain("realm=\"1234_SB1\"");
        }


        private async Task When()
        {
            _authParameter = null;

            A.CallTo(() => this.MessageHandler.SendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(callParams => {
                    var req = callParams.Arguments[0] as HttpRequestMessage;
                    _authScheme = req.Headers.Authorization.Scheme;
                    _authParameter = req.Headers.Authorization.Parameter;

                    return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
                });

            await _client.Get(
                "TSTDRV12345",
                new Uri("https://tstdrv12345.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=custscript1&deploy=custdeploy1"),
                _token,
                _tokenSecret);
        }

        public When_computing_the_authorization_header()
        {
            _client = new TestableRestClient(
                new HttpClient(new FakeMessageHandlerProxy(this.MessageHandler)),
                Options.Create(
                    new RestClientOptions {
                        ConsumerKey = _consumerKey,
                        ConsumerSecret = _consumerSecret
                    })
            );
        }

        // These sample tokens, nonce values and final signature are taken from http://lti.tools/oauth/

        private readonly string _consumerKey = "dpf43f3p2l4k3l03";
        private readonly string _consumerSecret = "kd94hf93k423kf44";
        private readonly string _token = "nnch734d00sl2jdk";
        private readonly string _tokenSecret = "pfkkdhi9sl3r4s00";

        class TestableRestClient: RestClient
        {
            protected override long ComputeTimestamp() => 1594207766;
            protected override string ComputeNonce() => "tUoTBMCLMiW";

            public TestableRestClient(HttpClient httpClient, IOptions<RestClientOptions> options): base(httpClient, options)
            {
            }
        }
    }
}
