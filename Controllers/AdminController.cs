using Agrisys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Controllers;

public class AdminController : Controller {
    private readonly UserManager<IdentityUser> _userManager;
    // Constructor to inject UserManager

    public AdminController(UserManager<IdentityUser> userManager) {
        _userManager = userManager;
    }

    // GET: Admin/Index or Admin/ListUsers
    public async Task<IActionResult> Index() {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    // GET: Admin/CreateUser
    public IActionResult CreateUser() {
        return View();
    }

    // POST: Admin/CreateUser
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel model) {
        if (ModelState.IsValid) {
            var user = new IdentityUser
                { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) {
                return View("Index");
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error.Description);
                Console.WriteLine(error.Description);
            }
        }

        return View(model);
    }

    // Example methods, details need to be filled in
    public Task EditUser(string id) {
        // Logic to retrieve user and return an edit view
        Console.WriteLine(id);
        return Task.CompletedTask;
    }

    // GET: Admin/DeleteUser/5
    public async Task<IActionResult> DeleteUser(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null) {
            await _userManager.DeleteAsync(user);
        }

        return RedirectToAction(nameof(Index));
    }
}