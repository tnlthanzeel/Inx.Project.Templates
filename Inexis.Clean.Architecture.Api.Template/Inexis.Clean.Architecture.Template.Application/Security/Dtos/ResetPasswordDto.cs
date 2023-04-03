namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed record ResetPasswordDto
{
    public string Token { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string NewPassword { get; init; } = null!;
    public string ConfirmPassword { get; init; } = null!;
}
