using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class AdminController : Controller {
    public IActionResult Index() {
        return View();
    }
}

