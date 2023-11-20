using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Models {
    public class IdentityContext: IdentityDbContext<IdentityUser> {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }
    }
}