﻿using Inexis.Clean.Architecture.Template.Core.Security.Entities;
using Inexis.Clean.Architecture.Template.SharedKernal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inexis.Clean.Architecture.Template.Persistence.Configurations.UserConfigs;

internal sealed class UserRoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
                new Role
                {
                    Id = AppConstants.SuperAdmin.SuperAdminRoleId,
                    ConcurrencyStamp = "d6b0ba4f-67d0-4a6d-b37d-60f891d0875d",
                    Name = AppConstants.SuperAdmin.SuperAdminRoleName,
                    NormalizedName = AppConstants.SuperAdmin.SuperAdminRoleName.ToUpper(),
                    IsDefault = true
                }
            );
    }
}
