using Microsoft.AspNetCore.Identity;

namespace Agrisys.Models;

public class CreateUserViewModel {
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}