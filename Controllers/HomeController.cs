using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agrisys.Models;
using Agrisys.Utils;

namespace Agrisys.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Logging()
    {
        var logData = Logger.Read();
        ViewData["LogColumnCount"] = logData.columnCount;
        ViewData["LogRows"] = logData.data;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
