using Agrisys.Models;
using Agrisys.Utils;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data {
    public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            DatabaseContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();
            HomeDbContext homeDbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HomeDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (homeDbContext.Database.GetPendingMigrations().Any()) {
                homeDbContext.Database.Migrate();
            }

            SeedHomeView(homeDbContext);
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

        public static void SeedHomeView(HomeDbContext homeDbContext) {
            var SeedHomeViewModel = new HomeViewModel {
                LogMessages = Logger.ReadStrings(),
                SiloAmount = 12.1,
                SiloState = State.InProgress,
                MixerAmount = 3,
                MixerState = State.InProgress,
                HatchOneState = State.Awaiting,
                DistributorAmount = 0,
                DistributorState = State.Awaiting,
                HatchTwoState = State.Awaiting,
                FanAmount = 0,
                FanState = State.Awaiting,
                Pressure = 0,
                TargetId = "Target1b25ok"
            };

            _ = homeDbContext.HomeViewModels.Add(SeedHomeViewModel);
            _ = homeDbContext.SaveChanges();
        }
    }
}
