using Newtonsoft.Json;
using System.Net;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class ResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
