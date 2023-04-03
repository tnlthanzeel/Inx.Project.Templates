namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed class UserRoleDto
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public bool IsDefault { get; set; } = false;
}
