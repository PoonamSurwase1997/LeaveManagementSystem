using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Configuration
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "a6b6297c-917c-41ad-8e9b-8e737e3667a1",
                   UserId = "ec85b359-72d3-49d6-aa1e-45893c685e5c"
               });
        }
    }
}
