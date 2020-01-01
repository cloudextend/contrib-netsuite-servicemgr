using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite
{
    public class ClientFactoryOptions
    {
        public string ApplicationId { get; set; }

        public string ConsumerKey { get; set; }

        public string ConsumerSecret { get; set; }

        public string Name { get; set; }
    }
}
