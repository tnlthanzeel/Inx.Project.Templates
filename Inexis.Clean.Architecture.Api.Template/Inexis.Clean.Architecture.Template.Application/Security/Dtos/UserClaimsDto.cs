namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed class UserClaimsDto
{
    public string ClaimType { get; init; } = null!;

    public string ClaimValue { get; init; } = null!;
}
