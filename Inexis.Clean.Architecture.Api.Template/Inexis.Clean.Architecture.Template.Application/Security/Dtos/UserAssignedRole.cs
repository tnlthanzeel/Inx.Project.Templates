﻿namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed class UserAssignedRole
{
    public Guid UserId { get; init; }
    public IReadOnlyList<string> RoleNames { get; init; } = new List<string>();
}
