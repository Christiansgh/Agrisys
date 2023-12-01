using Agrisys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        
        public DbSet<Farm> Farms { get; set; }
        public DbSet<FarmUser> FarmUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FarmUser>()
                .HasKey(fu => new { fu.FarmId, fu.UserId });

            builder.Entity<FarmUser>()
                .HasOne<IdentityUser>(fu => fu.User)
                .WithMany()
                .HasForeignKey(fu => fu.UserId)
                .IsRequired();

            builder.Entity<FarmUser>()
                .HasOne(fu => fu.Farm)
                .WithMany()
                .HasForeignKey(fu => fu.FarmId)
                .IsRequired();
        }
    }
}