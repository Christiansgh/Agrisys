using System.Diagnostics;

using Agrisys.Models;
using Agrisys.Utils;

using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class LoggingController : Controller {
    public IActionResult Index() {
        var logData = Logger.Read();
        ViewData["LogColumnCount"] = logData.columnCount;
        ViewData["LogRows"] = logData.data;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
