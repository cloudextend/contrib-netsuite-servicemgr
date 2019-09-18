using Celigo.ServiceManager.NetSuite;
using SuiteTalk;
using System;

namespace Celigo.SuiteTalk.PassportProviders.EnvironmentVariables
{
    public class EnvVariableTokenPassportProvider : ITokenPassportProvider
    {
        private readonly object _tokenLock = new object();
        private TokenPassport _tokenPassport;

        private readonly string consumerSecretVariable;
        private readonly string consumerKeyVariable;
        private readonly string tokenVarible;
        private readonly string tokenSecretVariable;
        private readonly string accountVariable;

        public TokenPassport GetTokenPassport()
        {
            if (_tokenPassport == null)
                lock (_tokenLock)
                {
                    if (_tokenPassport == null)
                    {
                        string env(string varName) {
                            string value = Environment.GetEnvironmentVariable(varName);
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                return value;
                            }
                            else
                            {
                                throw new InvalidOperationException(varName + " environment variable was not set.");
                            }
                        }

                        string consumerSecret = env(this.consumerSecretVariable);
                        string consumerKey = env(this.consumerKeyVariable);

                        var passportBuilder = new DefaultTokenPassportBuilder(consumerKey, consumerSecret);

                        string token = env(this.tokenVarible);
                        string tokenSecret = env(this.tokenSecretVariable);
                        string account = env(this.accountVariable);

                        _tokenPassport = passportBuilder.Build(account, token, tokenSecret);
                    }
                }
            return _tokenPassport;
        }

        public EnvVariableTokenPassportProvider(string variablePrefix)
        {
            this.consumerKeyVariable = variablePrefix + "__ConsumerKey";
            this.consumerSecretVariable = variablePrefix + "__ConsumerSecret";
            this.tokenVarible = variablePrefix + "__Token";
            this.tokenSecretVariable = variablePrefix + "__TokenSecret";
            this.accountVariable = variablePrefix + "__Account";
        }

        public EnvVariableTokenPassportProvider()
        {
            this.consumerKeyVariable = "Celigo__NetSuite__TBA__ConsumerKey";
            this.consumerSecretVariable = "Celigo__NetSuite__TBA__ConsumerSecret";
            this.tokenVarible = "netsuite-tba-token";
            this.tokenSecretVariable = "netsuite-tba-token-secret";
            this.accountVariable = "netsuite-account";
        }
    }
}
