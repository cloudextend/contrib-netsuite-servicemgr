using Celigo.ServiceManager.NetSuite;
using Celigo.SuiteTalk.PassportProviders.EnvironmentVariables;
using SuiteTalk;
using System;

namespace Tests.Celigo.ServiceManager.NetSuite.Meta
{
    class TestConfiguration
    {
        public string Account { get; set; }
        public string ApplicationId { get; set; }
        public ITokenPassportProvider TokenPassportProvider { get; set; }

        public TestConfiguration()
        {
            this.ApplicationId = Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__AppId");
            this.Account = Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__Account");
            this.TokenPassportProvider = new EnvVariableTokenPassportProvider("Celigo__UnitTests__NetSuite__TBA");
        }
    }
}
