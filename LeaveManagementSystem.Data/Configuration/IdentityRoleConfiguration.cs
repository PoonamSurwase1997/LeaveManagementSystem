using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configuration
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole
               {
                   Id = "1d429a03-d2df-4ddf-9a0d-1b07dc9735ce",
                   Name = "Employee",
                   NormalizedName = "EMPLOYEE"
               },
               new IdentityRole
               {
                   Id = "a063c476-9046-455c-89a6-79c6d3ed0e4c",
                   Name = "Supervisor",
                   NormalizedName = "SUPERVISOR"
               },
               new IdentityRole
               {
                   Id = "a6b6297c-917c-41ad-8e9b-8e737e3667a1",
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR"
               });

        }
    }
}
