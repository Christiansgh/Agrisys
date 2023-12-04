using Agrisys.Models;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data; 

public class DatabaseContext : DbContext {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        
    public DbSet<Farm> Farms { get; set; }
    public DbSet<FarmUser> FarmUsers { get; set; }

    
}