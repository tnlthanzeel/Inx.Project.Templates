namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public record UserSummaryDto
{
    public Guid Id { get; init; }
    public string Email { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public IReadOnlyList<string> Roles { get; set; } = new List<string>();

}