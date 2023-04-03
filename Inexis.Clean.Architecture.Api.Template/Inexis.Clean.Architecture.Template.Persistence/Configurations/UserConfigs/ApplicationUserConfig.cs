﻿using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;
using Inexis.Clean.Architecture.Template.SharedKernal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inexis.Clean.Architecture.Template.Persistence.Configurations.UserConfigs;

internal sealed class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasQueryFilter(w => w.IsDeleted == false);

        builder
            .HasOne(b => b.UserProfile)
            .WithOne(f => f.ApplicationUser)
            .HasForeignKey<UserProfile>(s => s.Id);

        var user = new ApplicationUser
        {
            Id = AppConstants.SuperAdmin.SuperUserId,
            UserName = "admin",
            Email = "admin@vpms.com",
            LockoutEnabled = false,
            PhoneNumber = "1234567890",
            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 30)),
            NormalizedEmail = "admin@vpms.com".ToUpper(),
            NormalizedUserName = "admin".ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = "70428f75-0a6f-4d92-a2cd-ae4e0cdbd10f",
            ConcurrencyStamp = "70428f75-0a6f-4d92-a2cd-ae4e0cdbd10f",
            PasswordHash = "AQAAAAEAACcQAAAAEJZHh/S5hmTm+8BR8ssy2GyMm04koddmCJLLGetMIWDEwKTXVwjow5mnIKwK5ExMNA=="
        };
        builder.HasData(user);
    }
}