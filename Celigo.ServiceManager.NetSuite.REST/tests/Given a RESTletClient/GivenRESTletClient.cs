using Celigo.ServiceManager.NetSuite.REST;
using Microsoft.Extensions.Options;
using System.Net.Http;
using _.Utils;

namespace _.Given_a_RestletClient
{
    public class GivenRestletClient: RestletTestBase
    {
        protected RestletClient Client { get; }

        public GivenRestletClient()
        {
            var httpClient = new HttpClient(new FakeMessageHandlerProxy(MessageHandler));

            var options = Options.Create(RestClientOptions);

            Client = new RestletClient(httpClient, options, RestletConfig);
        }

        protected bool IsExpectedOAuthRequest(HttpRequestMessage m, string expectedUrl) =>
            m.RequestUri.AbsoluteUri == expectedUrl && m.Headers.Authorization.Scheme == "OAuth";
        
        protected bool IsExpectedBasicRequest(HttpRequestMessage m, string expectedUrl) =>
            m.RequestUri.AbsoluteUri == expectedUrl && m.Headers.Authorization.Scheme == "NLAuth";
    }
}