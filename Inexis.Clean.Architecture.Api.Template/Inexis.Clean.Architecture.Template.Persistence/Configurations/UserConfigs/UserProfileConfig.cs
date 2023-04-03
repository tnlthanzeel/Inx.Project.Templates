using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;
using Inexis.Clean.Architecture.Template.SharedKernal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inexis.Clean.Architecture.Template.Persistence.Configurations.UserConfigs;

internal sealed class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(AppConstants.StringLengths.FirstName);

        builder.Property(p => p.LastName).IsRequired().HasMaxLength(AppConstants.StringLengths.LastName);

        builder.Property(p => p.TimeZone).HasMaxLength(200).IsRequired();

        builder.HasData(new UserProfile()
        {
            Id = AppConstants.SuperAdmin.SuperAdminRoleId,
            FirstName = "Super",
            LastName = "Admin",
            TimeZone = "Sri Lanka Standard Time"
        });
    }
}
