using System;
using System.Net.Http;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.TSA;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite.AuthorizationFlow
{
    public class RevokeTokenSignatureAlgorithmTests : RevokeTokenService
    {
        // Parameters taken from https://tstdrv231585.app.netsuite.com/app/help/helpcenter.nl?fid=section_157652573296.html

        private const string _callbackUrl = "https://my.example.com/TBA/?callbackRequest";

        private string _generatedAuthHeader;
        private string _baseString;

        [Fact]
        public async Task Generates_the_expected_oauth_signature()
        {
            await this.RevokeToken("1234567", _tokenKey, _tokenSecret);
            _baseString.Should().Be("GET&https%3A%2F%2F1234567.restlets.api.netsuite.com%2Frest%2Frevoketoken&consumerKey%3D60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5%26oauth_consumer_key%3D60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5%26oauth_nonce%3DwjRgXQPWhYtKl0A7bO8Z%26oauth_signature_method%3DHMAC-SHA256%26oauth_timestamp%3D1576079512%26oauth_token%3D447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179%26oauth_version%3D1.0%26token%3D447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179");
            _generatedAuthHeader.Should().StartWith("OAuth ");
            _generatedAuthHeader.Should().Contain("oauth_signature=\"IQwMGWzHT%2BN%2Bh%2BAlakCKto0FMhx9j53kL713Xijl9Io%3D\"");
            _generatedAuthHeader.Should().Contain("realm=\"1234567\"");
            _generatedAuthHeader.Should().Contain("oauth_consumer_key=\"60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5\"");
            _generatedAuthHeader.Should().Contain("oauth_token=\"447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179\"");
            _generatedAuthHeader.Should().Contain("oauth_signature_method=\"HMAC-SHA256\"");
            _generatedAuthHeader.Should().Contain("oauth_timestamp=\"1576079512\"");
            _generatedAuthHeader.Should().Contain("oauth_nonce=\"wjRgXQPWhYtKl0A7bO8Z\"");
            _generatedAuthHeader.Should().Contain("oauth_version=\"1.0\"");
        }

        protected override string ComputeNonce() => "wjRgXQPWhYtKl0A7bO8Z";

        protected override long ComputeTimestamp() => 1576079512;

        private const string _consumerKey = "60712990bc09623786e7047c226bcb3f86d49dca0b04efc21001dc76d97a81f5";
        private const string _consumerSecret = "bd47b9c7e990a4f209db0217c023d0ba2274aafa7183f2cc310fff8bf24335b8";

        private const string _tokenKey = "447d0cba5569a2d616e32a537110bc8c10ebcf42cc1fa34d6f76d08531abc179";
        private const string _tokenSecret = "f4ae9dbe08acf7105db4d829391de42f387d1a8d6ddc2b41827ce142445445c1";

        protected override string ComputeSignature(string baseString, string tokenSecret)
        {
            _baseString = baseString;
            return base.ComputeSignature(baseString, tokenSecret);
        }

        protected override Task<RevokeTokenResponse> MakeRequest(
            string authorizationHeader, 
            Func<HttpClient, Task<HttpResponseMessage>> makeRequestFn, 
            Func<HttpResponseMessage, Task<RevokeTokenResponse>> successHandler)
        {
            _generatedAuthHeader = authorizationHeader;
            return Task.FromResult(new RevokeTokenResponse());
        }

        public RevokeTokenSignatureAlgorithmTests() 
            : base(null, Options.Create(new TokenServiceOptions { ConsumerKey = _consumerKey, ConsumerSecret = _consumerSecret, CallbackUrl = _callbackUrl }))
        {
        }
    }
}