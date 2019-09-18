using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class RequestTokenResponse
    {
        // [JsonProperty("oauth_token")]
        public string Token { get; set; }

        // [JsonProperty("oauth_token_secret")]
        public string TokenSecret { get; set; }

        // [JsonProperty("oauth_callback_confirmed")]
        public bool IsCallbackConfirmed { get; set; }

        public ResponseError Error { get; set; }
    }

    public class ResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
