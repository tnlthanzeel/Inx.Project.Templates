namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public record UserCreateDto(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    string Role,
    string TimeZone,
    IEnumerable<Guid> CompanyIds,
    IEnumerable<string> Permissions
    );

