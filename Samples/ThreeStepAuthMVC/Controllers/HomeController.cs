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

    public IActionResult Authorize(string oauth_token, string oauth_verifier)
    {
        ViewBag.State = "Authorizing...";
        ViewBag.OauthToken = oauth_token;
        ViewBag.OauthVerifier = oauth_verifier;
        ViewBag.UserToken = ViewBag.UserSecret = "";

        return View("Authorize");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}