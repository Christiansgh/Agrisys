using Microsoft.EntityFrameworkCore;

namespace Agrisys.Models {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<User> Users => Set<User>();
    }
}