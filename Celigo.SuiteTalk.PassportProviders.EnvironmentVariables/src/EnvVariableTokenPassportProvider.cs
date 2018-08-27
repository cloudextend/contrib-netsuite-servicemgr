using Celigo.ServiceManager.NetSuite;
using SuiteTalk;
using System;

namespace Celigo.SuiteTalk.PassportProviders.EnvironmentVariables
{
    public class EnvVariableTokenPassportProvider : ITokenPassportProvider
    {
        private readonly object _tokenLock = new object();
        private TokenPassport _tokenPassport;

        public TokenPassport GetTokenPassport()
        {
            if (_tokenPassport == null)
                lock (_tokenLock)
                {
                    if (_tokenPassport == null)
                    {
                        string env(string varName) {
                            string value = Environment.GetEnvironmentVariable(varName);
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                throw new InvalidOperationException(varName + " environment variable was not set.");
                            }
                            return value;
                        }

                        string consumerSecret = env("Celigo_NetSuite_TBA__ConsumerSecret");
                        string consumerKey = env("Celigo_NetSuite_TBA__ConsumerKey");

                        var passportBuilder = new DefaultTokenPassportBuilder(consumerKey, consumerSecret);

                        string token = env("netsuite-tba-token");
                        string tokenSecret = env("netsuite-tba-token-secret");
                        string account = env("netsuite-account");

                        _tokenPassport = passportBuilder.Build(account, token, tokenSecret);
                    }
                }
            return _tokenPassport;
        }

        public EnvVariableTokenPassportProvider()
        {

        }
    }
}
