using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agrisys.Models;




namespace Agrisys.Controllers;

public class EditController : Controller
{
    private readonly ILogger<EditController> _logger;

    public EditController(ILogger<EditController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult SiloNr()
      
    {
        return View();
    }

    
    public IActionResult Portion()
      
    {
        return View();
    }
      

        public ViewResult Index()
    {
        return View();
    }


    public IActionResult Blæser()

    {
        return View();
    }


    //public ViewResult Silo()
    //{
    //    return View();

    //}


    public ViewResult Mixer()
    {
        return View();
    }


    public ViewResult Fordeler()
    {
        return View();
    }


    [HttpGet]
    public ViewResult Silo() 
    {
        return View();
    }

    [HttpPost]
    public ViewResult Silo(DropOption dropOption) 
    {
        Repository.AddResponse(dropOption);

        return View("Bekræft", dropOption);
        
    }
    public ViewResult ListDropOption()
    {
        return View(Repository.DropOption.Where(r => r.SiloIndhold == true));
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
