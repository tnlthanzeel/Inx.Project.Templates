namespace Inexis.Clean.Architecture.Template.Core.Security.Dtos;

public sealed record UpdateUserProfileDto
    (
    string FirstName,
    string LastName,
    string TimeZone
    );
