using EventMaker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventMaker.Data
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Direction> Directions { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserRequest> UsersRequests { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity => entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(entity =>
                entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable("UserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable("UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable("RoleClaims"));
        }

    }
}
