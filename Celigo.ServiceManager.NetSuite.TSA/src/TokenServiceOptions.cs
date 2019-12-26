using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public class TokenServiceOptions
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }

        public string CallbackUrl { get; set; } = Environment.GetEnvironmentVariable("Celigo__NetSuite__TBA__CallbackUrl");
    }
}
