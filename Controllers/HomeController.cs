using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agrisys.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


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

    public IActionResult SiloNr()

    {
        ViewBag.FoderSelectedList = new SelectList(GetFoder(), "Id", "Name");
        return View();
    }

    private List<SiloIndhold> GetFoder()
    {
        var foder = new List<SiloIndhold>();
        foder.Add(new SiloIndhold() { Id = 1, Name = "Havre" });
        foder.Add(new SiloIndhold() { Id = 2, Name = "Byg" });
        foder.Add(new SiloIndhold() { Id = 3, Name = "Hvede" });

        return foder;
    }



    public ViewResult HovedMenu()
    {
        return View();
    }


    public ViewResult Silo()
    {

        ViewBag.FoderSelectedList = new SelectList(GetFoder(), "Id", "Name");
        return View();
    }


    public ViewResult Mixer()
    {
        return View();
    }

    public ViewResult Fordeler()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
