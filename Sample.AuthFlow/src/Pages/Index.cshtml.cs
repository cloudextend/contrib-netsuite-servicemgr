using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celigo.ServiceManager.NetSuite;
using Celigo.ServiceManager.NetSuite.TSA;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Sample.AuthFlow.Pages
{
    public class IndexModel : PageModel
    {
        public string AccountNumber { get; set; }

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly TokenService _tokenService;

        public IndexModel(IHostingEnvironment env)
        {
            _hostingEnvironment = env;
            _tokenService = new TokenService(
                Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__ConsumerKey"),
                Environment.GetEnvironmentVariable("Celigo__UnitTests__NetSuite__TBA__ConsumerSecret")
           );
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Request.Query["oauth_verifier"].Any())
            {
                var auth = await _tokenService.GetAccessToken("TSTDRV231585",
                                Request.Query["oauth_token"].FirstOrDefault(),
                                Request.Cookies["oauth_token_secret"],
                                Request.Query["oauth_verifier"].FirstOrDefault());
            }

            var account = Request.Query["account"].FirstOrDefault();
            if (string.IsNullOrEmpty(account)) return new PageResult();

            string callbackUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            var tokenResponse = await _tokenService.GetRequestToken(account, callbackUrl);

            Response.Cookies.Append("oauth_token_secret", tokenResponse.TokenSecret, new CookieOptions {
                Domain = Request.Host.ToUriComponent(),
                MaxAge = TimeSpan.FromMinutes(5)
            });

            if (!tokenResponse.IsCallbackConfirmed) return new PageResult();
            return new RedirectResult($"https://{account}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token={tokenResponse.Token}&state={tokenResponse.TokenSecret}");
        }
    }
}
