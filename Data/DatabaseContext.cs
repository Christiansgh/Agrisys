using Agrisys.Models;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<User> Users => Set<User>();
    }
}