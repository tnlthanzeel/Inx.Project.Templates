namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public record UserDto(Guid Id,
    string Email,
    string UserName,
    string FirstName,
    string LastName,
    string TimeZone,
    IReadOnlyList<Guid> CompanyIds,
    IReadOnlyList<UserClaimsDto> Claims,
    IReadOnlyList<string> Roles
    );
