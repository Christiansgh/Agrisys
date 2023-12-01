using Microsoft.AspNetCore.Identity;

namespace Agrisys.Models; 

public class FarmUser {
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public int FarmId { get; set; }
    public Farm Farm { get; set; }
}