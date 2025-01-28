using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace _.Given_a_RestletClient
{
    public class When_making_a_parametered_DELETE_with_TBA : GivenRestletClient
    {
        [Fact]
        public async Task It_appends_the_parameters_to_the_url()
        {
            var response = await Client.Delete("TSTDRV12345", 
                                "DUMMYTOKEN", 
                                "DUMMYSECRET", 
                                new Dictionary<string, string>() {
                                    { "search", "foo" },
                                    {"filter", "b"}
                                }
                            );
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            A.CallTo(() =>
                    this.MessageHandler.SendAsync(
                        A<HttpRequestMessage>.That.Matches(m => m.RequestUri.Query.Contains("search=foo") && m.RequestUri.Query.Contains("filter=b")),
                        A<CancellationToken>.Ignored
                    ))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public async Task It_appends_url_encoded_query_param_to_the_url()
        {
            var response = await Client.Delete("TSTDRV12345", 
                "DUMMYTOKEN", 
                "DUMMYSECRET", 
                new Dictionary<string, string>() {
                    { "search", "%eddy" }
                }
            );
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            A.CallTo(() =>
                    this.MessageHandler.SendAsync(
                        A<HttpRequestMessage>.That.Matches(m => m.RequestUri.Query.Contains("search=%25eddy")),
                        A<CancellationToken>.Ignored
                    ))
                .MustHaveHappenedOnceExactly();
        }
    }
}