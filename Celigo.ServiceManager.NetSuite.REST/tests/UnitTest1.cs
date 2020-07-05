using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Celigo.ServiceManager.NetSuite.REST.UnitTests
{

    //class RESTletClient: RestClient 
    //{
    //    public RESTletClient(HttpClient httpClient, IOptions<RestClientOptions> options) : base(httpClient, options) { }
    //    public RESTletClient(HttpClient httpClient, string consumerKey, string consumerSecret) : base(httpClient, consumerKey, consumerSecret) { }

    //    protected override string ComputeNonce() => "eAh9lrFHHrQ";

    //    protected override long ComputeTimestamp() => 1593755638;

    //    public Task<RESTletResponse> Get()
    //    {
    //        const string account = "TSTDRV1460374";
    //        const string url = "https://tstdrv1460374.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=606&deploy=1";

    //        const string token = "1161592ca9d52baa74b967c702472767d948be69257d58d2eb9598af51f581cb";
    //        const string tokenSecret = "b032f240537c30e0131fea5baa1d559c1859a1377ccd6a2165dd1e9ca4f74729";

    //        return this.MakeGetRequest(account, new Uri(url), token, tokenSecret, r => Task.FromResult(new RESTletResponse()));
    //    }
    //}
    
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var options = Options.Create(new RestClientOptions {
                ConsumerKey = "0239812406b92c7b03aa4e862b3e156e5909efd135cbaad292ec803e69b7f44e",
                ConsumerSecret = "d5954f94cb866c4ab5f60385e1e34c561a83571e5e3bd4ef25ce4a370f14ee3a"
            });
                
            var config = new ConfigurationBuilder()
                            .Build();

            var svc = new ServiceCollection()
                .AddSingleton(options)
                .AddNetSuiteRestClientSupport(config)
                .AddRestletClient(config, new RestletConfig { Deploy = "1", Script = "606", RestletName = "sample" });

            var container = svc.BuildServiceProvider();
            var factory = container.GetRequiredService<IRestletClientFactory>();

            var client = factory.CreateClient("sample");

            const string account = "TSTDRV1460374";

            const string token = "1161592ca9d52baa74b967c702472767d948be69257d58d2eb9598af51f581cb";
            const string tokenSecret = "b032f240537c30e0131fea5baa1d559c1859a1377ccd6a2165dd1e9ca4f74729";
            var response = await client.Get(account, token, tokenSecret);
        }
    }
}