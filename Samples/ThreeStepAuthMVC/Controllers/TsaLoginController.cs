using Celigo.ServiceManager.NetSuite;
using Celigo.ServiceManager.NetSuite.TSA;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ThreeStepAuthMVC.Controllers
{
    [Route("api/tsa")]
    public class TsaLoginController : Controller
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRequestTokenService _requestTokenService;
        private readonly IRevokeTokenService _revokeTokenService;

        public TsaLoginController(IAccessTokenService accessTokenService, IRequestTokenService requestTokenService, IRevokeTokenService revokeTokenService)
        {
            _accessTokenService = accessTokenService;
            _requestTokenService = requestTokenService;
            _revokeTokenService = revokeTokenService;
        }

        [HttpGet("request-token")]
        public async Task<ActionResult<RequestTokenResponse>> RequestToken(string account)
        {
            var response = await _requestTokenService.GetRequestToken(account);
            return (response.Error == null) ? Ok(response) : StatusCode((int)response.Error.StatusCode, response);
        }

        [HttpGet("authorized-token")]
        public async Task<ActionResult<AccessTokenResponse>> AuthorizeToken(string account, string requestToken, string tokenSecret, string verifier)
        {
            var response = await _accessTokenService.GetAccessToken(account, requestToken, tokenSecret, verifier);
            return (response.Error == null) ? Ok(response) : StatusCode((int)response.Error.StatusCode, response);
        }

        [HttpGet("revoke-token")]
        public async Task<ActionResult> RevokeToken(string account, string token, string tokenSecret)
        {
            var response = await _revokeTokenService.RevokeToken(account, token, tokenSecret);
            return response.Error == null ? Ok(response) : StatusCode((int)response.Error.StatusCode, response);
        }
    }
}