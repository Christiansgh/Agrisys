using Agrisys.Utils;

using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class HomeController : Controller {
    public ViewResult Index() {

        List<string> logMessages = Logger.ReadStrings();

        return View("Index", logMessages);
    }
}
