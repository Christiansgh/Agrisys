using Agrisys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agrisys.Controllers;

public class LoginController : Controller {
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(SignInManager<IdentityUser> signInManager) {
        _signInManager = signInManager;
    }

    [Route("Login")]
    public IActionResult Login() {
        return View("Index");
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginViewModel model) {
        if (!ModelState.IsValid) {
            return View("Index", model);
        }

        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false,
            lockoutOnFailure: false);

        if (result.Succeeded) {
            return RedirectToAction("Index", "Home");
        }
        else {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View("Index", model);
        }
    }
}