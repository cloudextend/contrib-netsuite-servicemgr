using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public interface ITokenResponse
    {
        ResponseError Error { get; set; }
    }
}
