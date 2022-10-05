using EventMaker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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



            builder.Entity<Activity>().HasKey(e => e.Id);
            builder.Entity<Activity>().HasOne(e => e.Event).WithMany(t => t.Activities).HasForeignKey(e => e.EventId);
            builder.Entity<Activity>().HasOne(e => e.Moderator).WithMany(t => t.ModeratorActivities).HasForeignKey(e => e.ModeratorId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Activity>().HasOne(e => e.Winner).WithMany(t => t.WinnerActivities).HasForeignKey(e => e.WinnerId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Activity>().HasMany(e => e.UsersJury).WithMany(t => t.JuryActivities).UsingEntity("JuryInActivities");

            builder.Entity<City>().HasKey(e => e.Id);

            builder.Entity<Country>().HasKey(e => e.Id);

            builder.Entity<Direction>().HasKey(e => e.Id);

            builder.Entity<Event>().HasKey(e => e.Id);
            builder.Entity<Event>().HasOne(e => e.Direction).WithMany(t => t.Events).HasForeignKey(e => e.DirectionId);
            builder.Entity<Event>().HasOne(e => e.City).WithMany(t => t.Events).HasForeignKey(e => e.CityId);
            builder.Entity<Event>().HasOne(e => e.Organizer).WithMany(t => t.Events).HasForeignKey(e => e.OrganizerId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<User>().HasOne(e => e.Direction).WithMany(t => t.Users).HasForeignKey(e => e.DirectionId);
            builder.Entity<User>().HasOne(e => e.Event).WithMany(t => t.UsersJury).HasForeignKey(e => e.EventId);
            builder.Entity<User>().HasOne(e => e.Country).WithMany(t => t.Users).HasForeignKey(e => e.CountryId);

            builder.Entity<UserRequest>().HasKey(e => e.Id);
            builder.Entity<UserRequest>().HasOne(e => e.Activity).WithMany(t => t.UserRequests).HasForeignKey(e => e.ActivityId);
            builder.Entity<UserRequest>().HasOne(e => e.User).WithMany(t => t.Requests).HasForeignKey(e => e.UserId);

        }

    }
}
