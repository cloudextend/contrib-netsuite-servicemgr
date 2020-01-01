using SuiteTalk;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Celigo.SuiteTalk.PassportProviders.EnvironmentVariables
{
    public interface ITestPassportProvider: IPassportProvider
    {
        string GetAuthString();
    }

    /// <summary>
    /// Provides quick access to a Passport object constructed through NETSUITE_CREDS env variable.
    /// </summary>
    public class EnvVariablePassportProvider : ITestPassportProvider
    {
        private static readonly Regex authPattern = new Regex(@"(?<keyword>\w+)=(?<value>.*?)(,|$)", RegexOptions.Compiled);
        private readonly string credsEnvVariableName;

        public EnvVariablePassportProvider(): this("NETSUITE_CREDS") {}

        public EnvVariablePassportProvider(string envVariableName)
        {
            this.credsEnvVariableName = envVariableName;
        }

        public string GetAuthString()
        {
            var creds = Environment.GetEnvironmentVariable(this.credsEnvVariableName);
            if (string.IsNullOrWhiteSpace(creds)) throw new InvalidOperationException(this.credsEnvVariableName + " environment variable should be configured");

            return creds;
        }

        public Passport GetPassport()
        {
            string authHeader = GetAuthString();

            var matches = authPattern.Matches(authHeader);
            if (matches.Count < 3) throw new InvalidOperationException(this.credsEnvVariableName + " have been misconfigured");

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
}
