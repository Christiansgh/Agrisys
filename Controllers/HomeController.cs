using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agrisys.Models;

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
        List<List<string>> rows = new() {
            new() {"2023-11-26", "Benjamin", "FODRING" },
            new() {"2023-11-25", "Christian", "POOPING :D" },
            new() {"2023-11-27", "Mikkel", "MEMEING" },
            new() {"2023-11-25", "Christian", "FARTING" },
            new() {"2023-11-30", "Flemming", "STORYTELLING" },
        };

        ViewData["LogColumnCount"] = 4;
        ViewData["LogRows"] = rows;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
