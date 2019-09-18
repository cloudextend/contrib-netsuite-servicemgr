using Celigo.ServiceManager.NetSuite;
using Celigo.ServiceManager.NetSuite.TSA;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite.AuthorizationFlow
{
    public class AuthorizationFlowHelperInternalTests: DefaultTokenService
    {
        [Fact]
        public void Normalizes_the_parameters_when_generating_the_base_string()
        {
            string account = "3728804";
            string url = $"https://{account.ToLowerInvariant()}.restlets.api.netsuite.com/rest/requesttoken";

            var authHeader = this.GetAuthorizationHeaderValue(account, url, "https://my.example.com/TBA/?callbackRequest");
            authHeader.Should().Contain("oauth_signature=\"4zUP%2FzKlyrF9RJkEqvwaFXyO5QWch%2FoaotXfPVHkefc%3D\"");
        }

        protected override string ComputeNonce() => "yn7bszP95cuZWFGaCABm";

        protected override long ComputeTimestamp() => 1566899962;


        private static readonly string _consumerKey = "dd0f377a247b044011e584d9a376065cb9bda263cc7ee3f75d0bc04d793107af";
        private static readonly string _consumerSecret = "ie8b35043g010j90yo3irk6unzfyh5xcsdwj8gri9zyc37mb5kuvxjbaso0bkia2";

        public AuthorizationFlowHelperInternalTests(): base(_consumerKey, _consumerSecret)
        {
        }
    }
}
