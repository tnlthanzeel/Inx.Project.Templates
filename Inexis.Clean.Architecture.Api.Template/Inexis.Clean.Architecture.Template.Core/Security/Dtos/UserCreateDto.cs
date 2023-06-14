namespace Inexis.Clean.Architecture.Template.Core.Security.Dtos;

public record UserCreateDto(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    string Role,
    string TimeZone,
    IEnumerable<string> Permissions
    );

