using Agrisys.Data;
using Agrisys.Models;
using Agrisys.Utils;

using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class HomeController : Controller {
    private readonly IHomeRepository _repository;

    public HomeController(IHomeRepository repository) {
        _repository = repository;
    }

    public ViewResult Index() {
        var homeViewModel = _repository.GetHomeViewModel();
        return View("Index", homeViewModel);
    }
}
