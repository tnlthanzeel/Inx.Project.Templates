namespace Inexis.Clean.Architecture.Template.Domain.Claims;

public sealed class ApplicationClaimValues
{
    public sealed class SuperAdmin
    {
        public const string All = "all";
    }

    public sealed class User
    {
        public const string Create = "user.create";
        public const string View = "user.view";
        public const string Edit = "user.edit";
        public const string Delete = "user.delete";
    }

    public sealed class Role
    {
        public const string Create = "role.create";
        public const string View = "role.view";
        public const string UpdateRoleClaim = "role.roleclaim.update";
        public const string Delete = "role.delete";
    }
}
