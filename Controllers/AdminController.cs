﻿using Agrisys.Models;
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
        var model = new CreateUserViewModel {
            Roles = _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList()
        };

        return View(model);
    }

    // POST: Admin/CreateUser
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel model) {
        if (ModelState.IsValid) {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded && !string.IsNullOrEmpty(model.SelectedRole))
            {
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

    // Example methods, details need to be filled in
    public Task EditUser(string id) {
        // Logic to retrieve user and return an edit view
        Console.WriteLine(id);
        return Task.CompletedTask;
    }

    // GET: Admin/DeleteUser/
    public async Task<IActionResult> DeleteUser(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null) {
            await _userManager.DeleteAsync(user);
        }

        return RedirectToAction(nameof(Index));
    }
}