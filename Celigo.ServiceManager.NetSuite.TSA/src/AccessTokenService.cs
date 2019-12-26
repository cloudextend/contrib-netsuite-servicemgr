using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public interface IAccessTokenService
    {
        Task<AccessTokenResponse> GetAccessToken(string account, string token, string tokenSecret, string verifier);
    }

    public class AccessTokenService: TokenServiceBase<AccessTokenResponse>, IAccessTokenService
    {
        public AccessTokenService(HttpClient httpClient, IOptions<TokenServiceOptions> options): base(httpClient, options)
        {
        }

        public async Task<AccessTokenResponse> GetAccessToken(string account, string token, string tokenSecret, string verifier)
        {
            var oauthParms = this.GetCommonOAuthParameters();
            oauthParms.Add("oauth_verifier", verifier);
            oauthParms.Add("oauth_token", token);

            string url = $"https://{this.Subdomainify(account)}.restlets.api.netsuite.com/rest/accesstoken";
            string authHeaderValue = this.GetAuthorizationHeaderValue(account, url, oauthParms, tokenSecret);

            async Task<AccessTokenResponse> createResponse(HttpResponseMessage response) {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseParams = HttpUtility.ParseQueryString(responseBody);
                    return new AccessTokenResponse {
                        Token = responseParams.Get("oauth_token").Trim(),
                        TokenSecret = responseParams.Get("oauth_token_secret").Trim()
                    };
            };

            return await this.MakeRequest(authHeaderValue, c => c.PostAsync(url, null), createResponse);
        }
    }
}
