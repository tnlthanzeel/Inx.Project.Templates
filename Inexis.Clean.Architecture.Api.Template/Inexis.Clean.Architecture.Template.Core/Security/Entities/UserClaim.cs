﻿using Microsoft.AspNetCore.Identity;

namespace Inexis.Clean.Architecture.Template.Core.Security.Entities;

public sealed class UserClaim : IdentityUserClaim<Guid>
{
    public int? UserRoleClaimId { get; set; }
    public Guid? UserRoleId { get; set; }
}
