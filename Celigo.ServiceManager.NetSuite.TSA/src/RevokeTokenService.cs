using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public interface IRevokeTokenService
    {
        Task<RevokeTokenResponse> RevokeToken(string account, string token, string tokenSecret);
    }

    public class RevokeTokenService: TokenServiceBase<RevokeTokenResponse>, IRevokeTokenService
    {
        public RevokeTokenService(HttpClient httpClient, IOptions<TokenServiceOptions> options): base(httpClient, options)
        {
        }

        public async Task<RevokeTokenResponse> RevokeToken(string account, string token, string tokenSecret)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            if (token == null) throw new ArgumentNullException(nameof(token));

            string accountSpecificSubdomain = this.Subdomainify(account);
            string requestPath = $"https://{accountSpecificSubdomain}.restlets.api.netsuite.com/rest/revoketoken";
            string url = $"{requestPath}?consumerKey={this.ConsumerKey}&token={token}";

            var oauthParms = this.GetCommonOAuthParameters();
            oauthParms.Add("oauth_token", token);
            oauthParms.Add("token", token);
            oauthParms.Add("consumerKey", this.ConsumerKey);

            async Task<RevokeTokenResponse> createResponse(HttpResponseMessage response) {
                var responseBody = await response.Content.ReadAsStringAsync();
                return new RevokeTokenResponse();
            }

            string authHeaderValue = this.GetAuthorizationHeaderValue(account, requestPath, oauthParms, tokenSecret, "GET");

            return await this.MakeRequest(authHeaderValue, c => c.GetAsync(url), createResponse);
        }
    }
}
