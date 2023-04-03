using Inexis.Clean.Architecture.Template.SharedKernal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inexis.Clean.Architecture.Template.Persistence.Configurations.UserConfigs;

internal sealed class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(
               new IdentityUserRole<Guid>
               {
                   RoleId = Guid.Parse("e24f4cd1-0759-440e-9a2b-6072880392b6"),
                   UserId = AppConstants.SuperAdmin.SuperUserId,
               }
           );
    }
}
