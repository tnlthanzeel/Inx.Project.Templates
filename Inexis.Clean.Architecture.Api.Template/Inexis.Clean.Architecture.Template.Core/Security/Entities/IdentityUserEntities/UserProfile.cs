namespace Inexis.Clean.Architecture.Template.Core.Security.Entities.IdentityUserEntities;

public sealed class UserProfile
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName}";

    public string TimeZone { get; set; } = null!;

    public ApplicationUser ApplicationUser { get; set; } = null!;

}
