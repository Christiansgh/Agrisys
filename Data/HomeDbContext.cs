using Agrisys.Models;

using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data;

public class HomeDbContext : DbContext {
    public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }

    public DbSet<HomeViewModel>? HomeViewModels { get; set; }
}
