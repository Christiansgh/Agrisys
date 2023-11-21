using Agrisys.Models;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data {
    public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            DatabaseContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Users.Any()) {
                context.Users.AddRange(
                    new User {
                        Id = 69,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}