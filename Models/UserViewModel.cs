using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agrisys.Models;

public class UserViewModel {
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public string? SelectedRole { get; set; }
    public List<SelectListItem> Roles { get; set; } = new();
    public string? SelectedFarm { get; set; }
    public List<SelectListItem> Farms { get; set; } = new();
}