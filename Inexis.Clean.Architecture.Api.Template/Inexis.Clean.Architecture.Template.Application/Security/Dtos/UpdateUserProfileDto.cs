namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed record UpdateUserProfileDto
    (
    string FirstName,
    string LastName,
    string TimeZone
    );
