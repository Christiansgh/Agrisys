using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agrisys.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Agrisys.Controllers;

public class EditController : Controller
{
    private readonly ILogger<EditController> _logger;

    public EditController(ILogger<EditController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult SiloNr()
        //
        //
        //
        //Her laver jeg en dropdownliste for Silo
    {
        ViewBag.FoderSelectedList = new SelectList(GetFoder(), "Id", "Name");
        return View();
    }

    private List<SiloIndhold> GetFoder()
    {
        var foder = new List<SiloIndhold>();
        foder.Add(new SiloIndhold() { Id = 1, Name = "Silo 1: Havre" });
        foder.Add(new SiloIndhold() { Id = 2, Name = "Silo 2: Byg" });
        foder.Add(new SiloIndhold() { Id = 3, Name = "Silo 3: Hvede" });
        foder.Add(new SiloIndhold() { Id = 4, Name = "Silo 4: Rug" });
        foder.Add(new SiloIndhold() { Id = 5, Name = "Silo 5: Vitamin" });
        foder.Add(new SiloIndhold() { Id = 6, Name = "Silo 6: Antibiotika" });

        return foder;
    }

    public IActionResult Portion()

    //
    //
    //Her laver jeg en dropdownliste for Silo
      
    {
        ViewBag.PortionSelectedList = new SelectList(GetPortion(), "Nr", "Vægt", "Portion");
        return View();
    }

    private List<SiloPortion> GetPortion()
    {
        var portion = new List<SiloPortion>();
        portion.Add(new SiloPortion() { Nr = 1, Vægt = "0,7 kg", Portion = "8b"});
        portion.Add(new SiloPortion() { Nr = 2, Vægt = "1,2 kg", Portion = "2f" });
        portion.Add(new SiloPortion() { Nr = 3, Vægt = "1 kg", Portion = "12d" });

        return portion;
    }

    public IActionResult Omrører()

    //
    //
    //Her laver jeg en dropdownliste for mixeren
    {
        ViewBag.OmrørerSelectedList = new SelectList(GetOmrører(), "Id", "Tid", "Hastighed");
        return View();
    }



    private List<Omrører> GetOmrører()
    {
        var omrører = new List<Omrører>();
        omrører.Add(new Omrører() { Id = 1, Time = "4 min"});
        omrører.Add(new Omrører() { Id = 2, Time = "5 min" });
        omrører.Add(new Omrører() { Id = 2, Time = "2 min" });

        return omrører;
    }

    public IActionResult Mix()

    {
        ViewBag.MixSelectedList = new SelectList(GetMix(), "Id", "Navn");
        return View();
    }



    private List<FoderMix> GetMix()
    {
        var mix = new List<FoderMix>();
        mix.Add(new FoderMix() { Id = 1, Name = "Smågrise mix nr 7" });
        mix.Add(new FoderMix() { Id = 2, Name = "Voksen so" });
        mix.Add(new FoderMix() { Id = 2, Name = "Voksen orne" });

        return mix;
    }

    public IActionResult Speed()


    //
    //
    //Her laver jeg en dropdownliste for blæseren
    {
        ViewBag.SpeedSelectedList = new SelectList(GetSpeed(), "Hastighed");
        return View();
    }



    private List<Speed> GetSpeed()
    {
        var Hastighed = new List<Speed>();
        Hastighed.Add(new Speed() { fart = "4 m/sek" });
        Hastighed.Add(new Speed() { fart = "3 m/sek" });
        Hastighed.Add(new Speed() { fart = "6 m/sek" });

        return Hastighed;
    }
        public ViewResult Index()
    {
        return View();
    }


    public IActionResult Blæser()

    {
        ViewBag.BlæserSelectedList = new SelectList(GetTryk(), "lufttryk");
        return View();
    }

    private List<Blæser> GetTryk()
    {
        var tryk = new List<Blæser>();
        tryk.Add(new Blæser() { lufttryk = 1});
        
        return tryk;
    }

    //
    //
    //Her bliver SelectedList defineret med valgmuligheder

    public ViewResult Silo()
    {

        ViewBag.FoderSelectedList = new SelectList(GetFoder(), "Id", "Name");
        

        ViewBag.PortionSelectedList = new SelectList(GetPortion(), "Nr", "Vægt", "Portion");
        return View();

    }

    public ViewResult Mixer()
    {
        ViewBag.MixSelectedList = new SelectList(GetMix(), "Id", "Name");

        ViewBag.OmrørerSelectedList = new SelectList(GetOmrører(), "Id", "Time");

        ViewBag.SpeedSelectedList = new SelectList(GetSpeed(), "Speed");
           
        return View();
    }



    public ViewResult Fordeler()
    {
        ViewBag.BlæserSelectedList = new SelectList(GetSpeed(), "Lufttryk");
        return View();
    }

    [HttpPost]
    public ViewResult Silo(SiloIndhold silo) 
    { 
        return View(silo);
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
