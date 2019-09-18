using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class AccessTokenResponse
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public ResponseError Error { get; set; }
    }
}
