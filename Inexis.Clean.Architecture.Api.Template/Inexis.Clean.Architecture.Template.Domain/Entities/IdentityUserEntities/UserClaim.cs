using Microsoft.AspNetCore.Identity;

namespace Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;

public sealed class UserClaim : IdentityUserClaim<Guid>
{
    public int? UserRoleClaimId { get; set; }
    public Guid? UserRoleId { get; set; }
}
