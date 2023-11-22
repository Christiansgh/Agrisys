using Agrisys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class AdminController : Controller {
    private readonly UserManager<IdentityUser> _userManager;
    // Constructor to inject UserManager

    public AdminController(UserManager<IdentityUser> userManager) {
        _userManager = userManager;
    }

    // GET: Admin/CreateUser
    public IActionResult CreateUser() {
        return View();
    }

    // POST: Admin/CreateUser
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel model) {
        
        Console.WriteLine("Entered CreateUser method");
        
        if (ModelState.IsValid) {
            var user = new IdentityUser
                { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) {
                // Redirect to a success page or list of users
                Console.Write("Result: ");
                Console.WriteLine(result);
            }
            else {
                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                    Console.WriteLine(error.Description);
                }
            }
        }

        return View(model);
    }
}