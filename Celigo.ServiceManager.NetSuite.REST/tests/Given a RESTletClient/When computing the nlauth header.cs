using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.REST;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace _.Given_a_RestletClient
{
    public class When_computing_the_nlauth_header: GivenRestletClient
    {
        private string _authScheme;
        private string _authParameter;
        
        private const string _expectedHeader =
            "nlauth_account=123456, nlauth_email=jsmith%2B1%40example.com, nlauth_signature=du%25my%20p%40%24%24word%23, nlauth_role=37";
        
        [Fact]
        public async Task It_generates_the_expected_header()
        {
            await When();

            _authScheme.Should().Be("NLAuth");
            _authParameter.Should().Be(_expectedHeader);
        }

        private async Task When()
        {
            A.CallTo(() => this.MessageHandler.SendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(callParams => {
                    var req = callParams.Arguments[0] as HttpRequestMessage;
                    _authScheme = req.Headers.Authorization.Scheme;
                    _authParameter = req.Headers.Authorization.Parameter;

                    return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
                });

            await Client.Get(new Passport {
                Email = "jsmith+1@example.com",
                Password = "du%my p@$$word#",
                RoleId = "37",
                Account = "123456"
            });
        }
    }
}