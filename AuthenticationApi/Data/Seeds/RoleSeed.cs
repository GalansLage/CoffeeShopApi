using AuthenticationApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationApi.Data.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasIndex(p => p.RolName).IsUnique();

            builder.HasData(
                new Role
                {
                    Id = 1,
                    RolName = "Admin",
                },
                new Role
                {
                    Id = 2,
                    RolName = "User",
                }
                );
        }
    }
}
