using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.REST;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace _.Given_a_RestletClient
{
    public class When_making_a_parameterless_GET_with_creds: GivenRestletClient
    {
        [Fact]
        public async Task It_invokes_the_RESTlet_hosted_in_the_target_account()
        {
            var response = await this.Client.Get(new Passport { Account = "TSTDRV12345", Email = "a@b.com", Password = "DUMMYTKNSEC" });
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            
            A.CallTo(() => this.MessageHandler.SendAsync(
                A<HttpRequestMessage>.That.Matches(m => IsExpectedBasicRequest(m, ExpectedBasePath)), 
                A<CancellationToken>.Ignored)
            ).MustHaveHappenedOnceExactly();
        } 
    }
}