using Inexis.Clean.Architecture.Template.Domain.Claims;

namespace Inexis.Clean.Architecture.Template.Domain.ModulePermissions;

public sealed record PermissionSet(string DisplayName, string Key);

public sealed class AppModulePermissions
{
    public static IReadOnlyList<KeyValuePair<string, IReadOnlyList<PermissionSet>>> GetPermissionList()
    {
        return new List<KeyValuePair<string, IReadOnlyList<PermissionSet>>>
        {
            _userPermissions,
            _rolePermissions
        }.ToList();
    }

    public static IReadOnlyList<string> GetPermissionKeys()
    {
        var permissionList = GetPermissionList();
        var keys = permissionList.SelectMany(s => s.Value).Select(s => s.Key).ToList();

        return keys;
    }

    private static readonly KeyValuePair<string, IReadOnlyList<PermissionSet>> _userPermissions =
        new(key: "User", value: new[]
        {
            new PermissionSet( "View", ApplicationClaimValues.User.View),
            new PermissionSet( "Create", ApplicationClaimValues.User.Create),
            new PermissionSet( "Edit", ApplicationClaimValues.User.Edit),
            new PermissionSet( "Delete", ApplicationClaimValues.User.Delete),
        });

    private static readonly KeyValuePair<string, IReadOnlyList<PermissionSet>> _rolePermissions =
        new(key: "Role", value: new[]
        {
            new PermissionSet( "View", ApplicationClaimValues.Role.View),
            new PermissionSet( "Create", ApplicationClaimValues.Role.Create),
            new PermissionSet( "Update", ApplicationClaimValues.Role.UpdateRoleClaim),
            new PermissionSet( "Delete", ApplicationClaimValues.Role.Delete)
        });

}



