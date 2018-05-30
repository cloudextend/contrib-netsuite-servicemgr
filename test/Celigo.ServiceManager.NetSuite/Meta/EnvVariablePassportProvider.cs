using SuiteTalk;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tests.Celigo.ServiceManager.NetSuite.Meta
{
    interface ITestPassportProvider: IPassportProvider
    {
        string GetAuthString();
    }

    /// <summary>
    /// Provides quick access to a Passport object constructed through NETSUITE_CREDS env variable.
    /// </summary>
    class EnvVariablePassportProvider : ITestPassportProvider
    {
        private static readonly Regex authPattern = new Regex(@"(?<keyword>\w+)=(?<value>.*?)(,|$)", RegexOptions.Compiled);

        public string GetAuthString()
        {
            var creds = Environment.GetEnvironmentVariable("NETSUITE_CREDS");
            if (string.IsNullOrWhiteSpace(creds)) throw new InvalidOperationException("NETSUITE_CREDS environment variable should be configured");

            return creds;
        }

        public Passport GetPassport()
        {
            string authHeader = GetAuthString();

            var matches = authPattern.Matches(authHeader);
            if (matches.Count < 3) throw new InvalidOperationException("NETSUITE_CREDS have been misconfigured");

            var detailsMap = new Dictionary<string, string>(4);
            foreach (Match match in matches)
            {
                detailsMap.Add(match.Groups["keyword"].Value, match.Groups["value"].Value);
            }

            return new Passport {
                email = detailsMap["email"],
                password = detailsMap["password"],
                account = detailsMap["account"],
                role = new RecordRef { internalId = detailsMap["role"] }
            };
        }
    }

    class EnvVariableTokenPassportProvider : ITokenPassportProvider
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

                        string consumerSecret = env("NS_CONSUMER_SECRET");
                        string consumerKey = env("NS_CONSUMER_KEY");

                        var passportBuilder = new DefaultTokenPassportBuilder(consumerKey, consumerSecret);

                        string token = env("NS_TBA_TOKEN");
                        string tokenSecret = env("NS_TBA_TOKEN_SECRET");
                        string account = env("NS_ACCOUNT");

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
