using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class RevokeTokenResponse: ITokenResponse
    {
        public ResponseError Error { get; set; }
    }
}
