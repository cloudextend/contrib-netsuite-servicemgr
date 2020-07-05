using Celigo.ServiceManager.NetSuite.REST;
using FakeItEasy;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _.Given_a_RestletClient
{
    public interface IFakeMessageHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }

    public class FakeMessageHandlerProxy: HttpMessageHandler
    {
        private readonly IFakeMessageHandler _fakeHandler;

        public FakeMessageHandlerProxy(IFakeMessageHandler fakeHandler)
        {
            _fakeHandler = fakeHandler;
        }

        protected override Task<HttpResponseMessage> 
            SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) => 
                this._fakeHandler.SendAsync(request, cancellationToken);
       
    }

    public class GivenRestletClient
    {
        protected const string Script = "custscript1";
        protected const string Deploy = "custdeploy1";

        protected RestletClient Client { get; }

        protected IFakeMessageHandler MessageHandler { get; }

        protected RestletConfig RestletConfig { get; } = new RestletConfig { Deploy = Deploy, Script = Script };

        protected RestClientOptions RestClientOptions { get; } = new RestClientOptions { ConsumerKey = "DUMMYCONSUMERKEY", ConsumerSecret = "DUMMYCONSUMERSECRET" };

        public GivenRestletClient()
        {
            MessageHandler = A.Fake<IFakeMessageHandler>();
            A.CallTo(() => MessageHandler.SendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

            var httpClient = new HttpClient(new FakeMessageHandlerProxy(MessageHandler));

            var options = Options.Create(RestClientOptions);

            Client = new RestletClient(httpClient, options, RestletConfig);
        }

        protected bool IsExpectedRequest(HttpRequestMessage m, string expectedUrl) =>
            m.RequestUri.AbsoluteUri == expectedUrl && m.Headers.Authorization.Scheme == "OAuth";
    }
}