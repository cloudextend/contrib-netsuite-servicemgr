using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThreeStepAuthMVC.Models;

namespace ThreeStepAuthMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        Console.Write(_logger);
        return View();
    }

    public IActionResult Login(Account account)
    {
        

       // const account = loginData.account;
        //console.log(`Logging in to ${account}...`);

        // this._http.get<RequestTokenRespone>(`/api/tsa/request-token?account=${account}`)
        // .subscribe(
        //     response => {
        //         console.log(response);
        //
        //         sessionStorage.setItem("celigo_oauth_token_secret", response.tokenSecret);
        //         sessionStorage.setItem("celigo_account", account);
        //
        //         window.location.href = `https://${account}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token=${response.token}`;
        //     },
        //     error => {
        //         console.error(error);
        //     }
       // );
        return View("Privacy");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}