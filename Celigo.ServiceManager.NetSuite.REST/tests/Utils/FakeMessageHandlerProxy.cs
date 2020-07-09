using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _.Utils
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
}