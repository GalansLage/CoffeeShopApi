using AuthenticationApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationApi.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasIndex(p => p.Username).IsUnique();

            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Email = "angelalgas@gmail.com"
                },
                new User
                {
                    Id = 2, 
                    Username = "user",
                    Password = "user",
                    Email = "angelalgas@gmail.com"
                }
                );
        }
    }
}
