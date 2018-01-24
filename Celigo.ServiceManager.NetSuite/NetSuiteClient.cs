using SuiteTalk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite
{
    public class NetSuiteClient
    {
        public Passport Passport { get; set; }

        public ApplicationInfo ApplicationInfo { get; set; }

        public Preferences Preferences { get; set; }

        public TokenPassport TokenPassport { get; set; }

        public PartnerInfo PartnerInfo { get; set; }


    }
}
