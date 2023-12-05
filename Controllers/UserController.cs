using Agrisys.Data;
using Agrisys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Controllers;

public class UserController : Controller {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IRepository _repository;

    public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
        IRepository repository) {
        _userManager = userManager;
        _roleManager = roleManager;
        _repository = repository;
    }

    // GET: User
    public async Task<IActionResult> Index() {
        var users = await _userManager.Users.ToListAsync();
        return View("Index", users);
    }

    // GET: User/CreateUser
    public IActionResult CreateUser() {
        var farms = _repository.GetAllFarmsAsync().Result
            .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name })
            .ToList();

        var model = new UserViewModel {
            Roles = _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList(),
            Farms = farms
        };

        return View(model);
    }

    // POST: User/CreateUser
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserViewModel model) {
        if (ModelState.IsValid) {
            var user = new IdentityUser
                { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
            var createUserResult = await _userManager.CreateAsync(user, model.Password!);

            if (createUserResult.Succeeded) {
                if (!string.IsNullOrEmpty(model.SelectedRole)) {
                    await _userManager.AddToRoleAsync(user, model.SelectedRole);
                }

                foreach (var selectedFarm in model.SelectedFarms) {
                    var farmId = int.Parse(selectedFarm);
                    await _repository.AssignUserToFarm(user.Id, farmId);
                }

                return RedirectToAction("Index");
            }

            foreach (var error in createUserResult.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }

        // Repopulate roles and farms if returning to form
        model.Roles = _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
        model.Farms = _repository.GetAllFarmsAsync().Result
            .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name })
            .ToList();

        return View(model);
    }


    // GET: User/EditUser
    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            // Handle user not found, redirect to a list or show an error
            return RedirectToAction("Index");
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var allFarms = _repository.GetAllFarmsAsync().Result
            .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name })
            .ToList();
        var userFarms = _repository.GetFarmsByUserId(user.Id).Result
            .Select(f => f.Id.ToString())
            .ToList();

        var model = new UserViewModel
        {
            Id = id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Roles = await _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToListAsync(),
            SelectedRole = userRoles.FirstOrDefault(), // Assuming single role
            Farms = allFarms,
            SelectedFarms = userFarms
        };

        return View(model);
    }



    // POST: User/EditUser/{id}
    [HttpPost]
    public async Task<IActionResult> EditUser(UserViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(model.Id!);
        if (user == null) {
            ModelState.AddModelError("", "User not found.");
            return View(model);
        }

        // Update user properties
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;

        var updateUserResult = await _userManager.UpdateAsync(user);
        if (!updateUserResult.Succeeded) {
            foreach (var error in updateUserResult.Errors) {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // Handle role assignment
        if (!string.IsNullOrEmpty(model.SelectedRole)) {
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles); // Remove past roles
            await _userManager.AddToRoleAsync(user, model.SelectedRole); // Add new role
        }

        // Handle farm assignments
        var existingFarmAssignments = await _repository.GetFarmsByUserId(user.Id);

        // Remove unselected farms
        var farmAssignments = existingFarmAssignments.ToList();
        foreach (var existingFarm in farmAssignments) {
            if (!model.SelectedFarms.Contains(existingFarm.Id.ToString())) {
                await _repository.RemoveUserFromFarm(user.Id, existingFarm.Id);
            }
        }

        // Add new farms
        foreach (var selectedFarmId in model.SelectedFarms) {
            if (farmAssignments.All(f => f.Id.ToString() != selectedFarmId)) {
                await _repository.AssignUserToFarm(user.Id, int.Parse(selectedFarmId));
            }
        }

        return RedirectToAction("Index");
    }


    // GET: User/ConfirmDeleteUser/{id}
    public async Task<IActionResult> ConfirmDeleteUser(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) {
            return NotFound();
        }

        var model = new UserViewModel {
            Email = user.Email,
        };

        return View(model);
    }

    // POST: User/DeleteUser/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUserConfirmed(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null) {
            await _userManager.DeleteAsync(user);
        }

        return RedirectToAction("Index");
    }
}