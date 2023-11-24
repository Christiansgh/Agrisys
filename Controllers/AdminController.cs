using Agrisys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Controllers;

public class AdminController : Controller {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: Admin/Index or Admin/ListUsers
    public async Task<IActionResult> Index() {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    // GET: Admin/CreateUser
    public IActionResult CreateUser() {
        var model = new UserViewModel {
            Roles = _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList()
        };

        return View(model);
    }

    // POST: Admin/CreateUser
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserViewModel model) {
        if (ModelState.IsValid) {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded && !string.IsNullOrEmpty(model.SelectedRole)) {
                await _userManager.AddToRoleAsync(user, model.SelectedRole);
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error.Description);
                Console.WriteLine(error.Description);
            }
        }
        
        // Repopulate roles if returning to form
        model.Roles = _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

        return View(model);
    }
    
    public async Task<IActionResult> EditUser(string id) {
        var user = await _userManager.FindByIdAsync(id);
        var model = new UserViewModel {
            Id = id,
            Email = user!.Email,
            PhoneNumber = user.PhoneNumber,
            Roles = await _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToListAsync()
        };

        // If you need to set the selected role
        var userRoles = await _userManager.GetRolesAsync(user);
        if (userRoles.Any()) {
            model.SelectedRole = userRoles.First();  // Assuming single role for simplicity
        }

        return View(model);
    }
    
    // POST: Admin/EditUser/{id}
    [HttpPost]
    public async Task<IActionResult> EditUser(UserViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }
        
        // Find user in db with given id
        var user = await _userManager.FindByIdAsync(model.Id!); // If user manually types wrong id in url it can be null
        
        // Check if user with given id exists
        if (user == null) {
            ModelState.AddModelError("", "User not found.");
            return View(model);
        }

        // Update user properties
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        
        // Update the user
        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded) {
            // Check if a new role was actually selected (if not, user keeps previous role)
            if (!string.IsNullOrEmpty(model.SelectedRole)) {
                // Handle role assignment
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles); // remove past role
                await _userManager.AddToRoleAsync(user, model.SelectedRole); // add current role
            }

            return RedirectToAction("Index");
        }
        
        // If there are errors, add them to the ModelState
        foreach (var error in result.Errors) {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    // GET: Admin/DeleteUser/{id}
    public async Task<IActionResult> DeleteUser(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null) {
            await _userManager.DeleteAsync(user);
        }

        return RedirectToAction(nameof(Index));
    }
}