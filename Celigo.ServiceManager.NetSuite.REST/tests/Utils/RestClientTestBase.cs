using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _.Utils
{
    public class RestClientTestBase
    {

        protected IFakeMessageHandler MessageHandler { get; }

        public RestClientTestBase()
        {
            MessageHandler = A.Fake<IFakeMessageHandler>();
            A.CallTo(() => MessageHandler.SendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
        }
    }
}
