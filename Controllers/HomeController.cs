using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class HomeController : Controller {
    public ViewResult Index() {
        string[] logMessages =  {
            "[2023-11-27 12:34:56] INFO: Application started.",
            "[2023-11-27 12:35:02] WARNING: Connection timeout.",
            "[2023-11-27 12:36:18] ERROR: Database connection failed.",
            "[2023-11-27 12:37:45] INFO: User logged in (username: johndoe).",
            "[2023-11-27 12:38:20] DEBUG: Processing data complete.",
            "[2023-11-27 12:39:55] ERROR: File not found: example.txt.",
            "[2023-11-27 12:40:10] INFO: Application closed."
        };

        return View("Index", logMessages);
    }
}
