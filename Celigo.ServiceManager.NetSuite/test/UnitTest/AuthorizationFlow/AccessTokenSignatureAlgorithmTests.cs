using System;
using System.Net.Http;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.TSA;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite.AuthorizationFlow
{
    public class AccessTokenSignatureAlgorithmTests : AccessTokenService
    {
        // Parameters taken from https://tstdrv231585.app.netsuite.com/app/help/helpcenter.nl?fid=section_157652573296.html

        private const string _callbackUrl = "https://my.example.com/TBA/?callbackRequest";

        private string _generatedAuthHeader;

        [Fact]
        public async Task Generates_the_expected_oauth_signature()
        {
            await this.GetAccessToken("1234567", _tokenKey, _tokenSecret, _verifier);
            _generatedAuthHeader.Should().Contain("oauth_signature=\"BBzawyjesZyFrwBjUAJfBsPDDGUY2FRdp3k4NwGDAO0%3D\"");
            _generatedAuthHeader.Should().Contain("realm=\"1234567\"");
            _generatedAuthHeader.Should().Contain("oauth_token=\"447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179\"");
            _generatedAuthHeader.Should().Contain("oauth_consumer_key=\"60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5\"");
            _generatedAuthHeader.Should().Contain("oauth_nonce=\"wjRgXQPWhYtKl0A7bO8Z\"");
            _generatedAuthHeader.Should().Contain("oauth_timestamp=\"1576079512\"");
            _generatedAuthHeader.Should().Contain("oauth_signature_method=\"HMAC-SHA256\"");
            _generatedAuthHeader.Should().Contain("oauth_version=\"1.0\"");
            _generatedAuthHeader.Should().Contain("oauth_verifier=\"3eff1ae4de6f924014b88e489a41e88da8ed1ba8bd5ad7684a71579d7e97f4ee\"");
        }

        protected override string ComputeNonce() => "wjRgXQPWhYtKl0A7bO8Z";

        protected override long ComputeTimestamp() => 1576079512;

        private const string _consumerKey = "60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5";
        private const string _consumerSecret = "60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5";

        private const string _tokenKey = "447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179";
        private const string _tokenSecret = "447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179";

        private const string _verifier = "3eff1ae4de6f924014b88e489a41e88da8ed1ba8bd5ad7684a71579d7e97f4ee";

        protected override Task<AccessTokenResponse> MakeRequest(
            string authorizationHeader, 
            Func<HttpClient, Task<HttpResponseMessage>> makeRequestFn, 
            Func<HttpResponseMessage, Task<AccessTokenResponse>> successHandler)
        {
            _generatedAuthHeader = authorizationHeader;
            return Task.FromResult(new AccessTokenResponse());
        }

        public AccessTokenSignatureAlgorithmTests() 
            : base(null, Options.Create(new TokenServiceOptions { ConsumerKey = _consumerKey, ConsumerSecret = _consumerSecret, CallbackUrl = _callbackUrl }))
        {
        }
    }
}