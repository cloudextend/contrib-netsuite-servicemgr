using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite.TSA;
using Microsoft.AspNetCore.Mvc;

namespace ThreeStepAuth.Controllers
{
    [Route("api/tsa")]
    public class TsaLoginController : Controller
    {
        private readonly ITokenService _tokenService;

        public TsaLoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("request-token")]
        public async Task<ActionResult<RequestTokenResponse>> RequestToken(string account, string callbackUrl)
        {
            var response = await _tokenService.GetRequestToken(account, callbackUrl);
            return (response.Error == null) ? Ok(response) : StatusCode((int)response.Error.StatusCode, response);
        }

        [HttpGet("authorized-token")]
        public async Task<ActionResult<AccessTokenResponse>> AuthorizeToken(string account, string requestToken, string tokenSecret, string verifier)
        {
            var response = await _tokenService.GetAccessToken(account, requestToken, tokenSecret, verifier);
            return (response.Error == null) ? Ok(response) : StatusCode((int)response.Error.StatusCode, response);
        }
    }
}
