using Agrisys.Data;
using Agrisys.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class FarmController : Controller {
    private readonly IRepository _db;

    public FarmController(IRepository repository) {
        _db = repository;
    }

    // GET: Farm/
    public async Task<IActionResult> Index() {
        var farms = await _db.GetAllFarmsAsync();
        return View("Index", farms);
    }

    // GET: Farm/CreateFarm
    public IActionResult CreateFarm() {
        var model = new FarmViewModel();
        return View(model);
    }

    // POST: Farm/CreateFarm
    [HttpPost]
    public async Task<IActionResult> CreateFarm(FarmViewModel model) {
        if (ModelState.IsValid) {
            var farm = new Farm(model.Name!);
            await _db.AddFarmAsync(farm);
        }

        return RedirectToAction("Index");
    }
    
    // GET: Farm/EditFarm
    public async Task<IActionResult> EditFarm(int id) {
        var farm = await _db.GetFarmByIdAsync(id);
        var model = new FarmViewModel {
            Id = id,
            Name = farm.Name
        };

        return View(model);
    }
    
    // POST: Farm/EditFarm/{id}
    [HttpPost]
    public async Task<IActionResult> EditFarm(FarmViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }
        
        var farm = await _db.GetFarmByIdAsync(model.Id);


        // Update farm properties
        farm.Name = model.Name!;

        // Update the farm
        await _db.UpdateFarmAsync(farm);

        return RedirectToAction("Index");
    }

    // GET: Farm/ConfirmDeleteFarm/{id}
    public async Task<IActionResult> ConfirmDeleteFarm(int id) {
        var farm = await _db.GetFarmByIdAsync(id);
        var model = new FarmViewModel {
            Name = farm.Name,
        };

        return View(model);
    }

    // POST: Farm/DeleteFarm/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFarmConfirmed(int id) {
        var farm = await _db.GetFarmByIdAsync(id);
        await _db.DeleteFarmAsync(id);

        return RedirectToAction("Index");
    }
}