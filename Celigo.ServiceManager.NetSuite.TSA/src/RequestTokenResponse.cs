using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class RequestTokenResponse: ITokenResponse
    {
        // [JsonProperty("oauth_token")]
        public string Token { get; set; }

        // [JsonProperty("oauth_token_secret")]
        public string TokenSecret { get; set; }

        // [JsonProperty("oauth_callback_confirmed")]
        public bool IsCallbackConfirmed { get; set; }

        public ResponseError Error { get; set; }
    }
}
