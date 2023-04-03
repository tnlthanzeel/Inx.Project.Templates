﻿namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed class PermissionTemplateDto
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public IReadOnlyList<UserClaimsDto> Claims { get; set; } = new List<UserClaimsDto>();
}
