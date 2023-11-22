using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers; 

public class AdminPageController : Controller {
    // GET
    public IActionResult Index() {
        return View();
    }
}