using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class HomeController : Controller {
    public ViewResult Index() {
        return View();
    }
}
