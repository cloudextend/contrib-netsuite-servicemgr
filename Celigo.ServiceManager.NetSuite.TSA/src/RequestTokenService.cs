using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public interface IRequestTokenService
    {
        Task<RequestTokenResponse> GetRequestToken(string account);
    }

    public class RequestTokenService: TokenServiceBase<RequestTokenResponse>, IRequestTokenService
    {
        public RequestTokenService(HttpClient httpClient, IOptions<TokenServiceOptions> options)
            : base(httpClient, options.Value.ConsumerKey, options.Value.ConsumerSecret, options.Value.CallbackUrl)
        {
        }

        public async Task<RequestTokenResponse> GetRequestToken(string account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            string accountSpecificSubdomain = this.Subdomainify(account);
            string url = $"https://{accountSpecificSubdomain}.restlets.api.netsuite.com/rest/requesttoken";

            async Task<RequestTokenResponse> createResponse(HttpResponseMessage response) {
                var responseBody = await response.Content.ReadAsStringAsync();
                var resultData = HttpUtility.ParseQueryString(responseBody);

                var token = resultData.Get("oauth_token").Trim();
                return new RequestTokenResponse {
                    IsCallbackConfirmed = "true".Equals(resultData.Get("oauth_callback_confirmed").Trim()),
                    Token = token,
                    TokenSecret = resultData.Get("oauth_token_secret").Trim(),
                    Next = $"https://{accountSpecificSubdomain}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token={token}"
                };
            }

            return await this.MakePostRequest(account, url, createResponse);
        }

        protected override async Task<RequestTokenResponse> HandleFailureResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
            {
                return new RequestTokenResponse {
                    Error = new ResponseError {
                        Code = response.StatusCode.ToString(),
                        Message = $"This account may not be configured to support 3-Step Authentication.",
                        StatusCode = response.StatusCode
                    }
                };
            }
            else
            {
                return await base.HandleFailureResponse(response);
            }
        }
    }
}
