using Microsoft.AspNetCore.Identity;

namespace Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;

public sealed class Role : IdentityRole<Guid>
{
    public Role() { }

    public Role(string roleName) : base(roleName) { }

    public bool IsDefault { get; set; } = false;
}

