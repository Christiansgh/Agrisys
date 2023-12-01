using Agrisys.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data {
    public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            DatabaseContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager) {
            if (!roleManager.RoleExistsAsync("Admin").Result) {
                var role = new IdentityRole {
                    Name = "Admin"
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync("Manager").Result) {
                var role = new IdentityRole {
                    Name = "Manager"
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync("User").Result) {
                var role = new IdentityRole {
                    Name = "User"
                };
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
