using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.REST;
using FakeItEasy;

namespace _.Utils
{
    public class RestletTestBase: RestClientTestBase
    {
        
        protected const string Script = "custscript1";
        protected const string Deploy = "custdeploy1";

        protected const string ExpectedBasePath = "https://tstdrv12345.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script="
                                                  + Script
                                                  + "&deploy="
                                                  + Deploy;

        protected RestletConfig RestletConfig { get; } = new RestletConfig { Deploy = Deploy, Script = Script };

        protected RestClientOptions RestClientOptions { get; } = new RestClientOptions { ConsumerKey = "DUMMYCONSUMERKEY", ConsumerSecret = "DUMMYCONSUMERSECRET" };
    }
}