namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed record UpdateUserPasswordDto(string CurrentPassword, string NewPassword, string ConfirmPassword);
