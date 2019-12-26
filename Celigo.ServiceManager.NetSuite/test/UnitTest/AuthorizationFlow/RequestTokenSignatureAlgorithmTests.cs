using System;
using System.Net.Http;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.TSA;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite.AuthorizationFlow
{
    public class RequestTokenSignatureAlgorithmTests : RequestTokenService
    {
        // Parameters taken from https://tstdrv231585.app.netsuite.com/app/help/helpcenter.nl?fid=section_157652390285.html

        private const string _callbackUrl = "https://my.example.com/TBA/?callbackRequest";
        private string _generatedAuthHeader;

        [Fact]
        public async Task Generates_the_expected_oauth_signature()
        {
            string account = "1234567";
            await this.GetRequestToken(account);

            _generatedAuthHeader.Should().Contain("oauth_signature=\"KPBoxLKj2sTc%2B7dmTT9K2dsVnK5r7n5%2FRopNeuZrn70%3D\"");
            _generatedAuthHeader.Should().StartWith("OAuth ");
            _generatedAuthHeader.Should().Contain("realm=\"1234567\"");
            _generatedAuthHeader.Should().Contain("oauth_callback=\"https%3A%2F%2Fmy.example.com%2FTBA%2F%3FcallbackRequest\"");
            _generatedAuthHeader.Should().Contain("oauth_consumer_key=\"60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5\"");
            _generatedAuthHeader.Should().Contain("oauth_nonce=\"bUvpxBX93OWo0FLswq5M\"");
            _generatedAuthHeader.Should().Contain("oauth_signature_method=\"HMAC-SHA256\"");
            _generatedAuthHeader.Should().Contain("oauth_timestamp=\"1575998103\"");
            _generatedAuthHeader.Should().Contain("oauth_version=\"1.0\"");
        }

        protected override string ComputeNonce() => "bUvpxBX93OWo0FLswq5M";

        protected override long ComputeTimestamp() => 1575998103;

        private const string _consumerKey = "60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5";
        private const string _consumerSecret = "60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5";

        protected override Task<RequestTokenResponse> MakeRequest(
            string authorizationHeader, 
            Func<HttpClient, Task<HttpResponseMessage>> makeRequestFn, 
            Func<HttpResponseMessage, Task<RequestTokenResponse>> successHandler)
        {
            _generatedAuthHeader = authorizationHeader;
            return Task.FromResult(new RequestTokenResponse());
        }

        public RequestTokenSignatureAlgorithmTests() : base(null, Options.Create(new TokenServiceOptions { ConsumerKey = _consumerKey, ConsumerSecret = _consumerSecret, CallbackUrl = _callbackUrl }))
        {
        }
    }
}