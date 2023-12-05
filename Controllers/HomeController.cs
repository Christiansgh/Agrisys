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

        //            new HomeViewModel {
        //            LogMessages = Logger.ReadStrings(),
        //            SiloAmount = 12.1,
        //            SiloState = State.InProgress,
        //            MixerAmount = 3,
        //            MixerState = State.InProgress,
        //            HatchOneState = State.Awaiting,
        //            DistributorAmount = 0,
        //            DistributorState = State.Awaiting,
        //            HatchTwoState = State.Awaiting,
        //            FanAmount = 0,
        //            FanState = State.Awaiting,
        //            Pressure = 0,
        //            TargetID = "Target1b25ok"
        //        };

        return View("Index", homeViewModel);
    }
}
