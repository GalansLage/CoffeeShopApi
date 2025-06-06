using AuthenticationApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Data
{
    public class AutheticationContext: DbContext
    {
        public AutheticationContext(DbContextOptions<AutheticationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");

            modelBuilder.Entity<UserRole>().HasKey(p => new {p.UserId,p.RoleId});

            modelBuilder.ApplyConfiguration(new Seeds.UserSeed());
            modelBuilder.ApplyConfiguration(new Seeds.RoleSeed());
            modelBuilder.ApplyConfiguration(new Seeds.UserRoleSeed());
        }

    }

}
