﻿namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed record UpdateUserDto
    (
    string Email,
    string FirstName,
    string LastName,
    IEnumerable<Guid> CompanyIds,
    string Role,
    string TimeZone,
    IEnumerable<string> Permissions);