using Inexis.Clean.Architecture.Template.Core.Security.Claims;

namespace Inexis.Clean.Architecture.Template.Core.Security.AuthPolicies;

public sealed class ApplicationAuthPolicy
{
    public sealed class UserPolicy
    {
        public const string Create = ApplicationClaimValues.User.Create;
        public const string View = ApplicationClaimValues.User.View;
        public const string Edit = ApplicationClaimValues.User.Edit;
        public const string Delete = ApplicationClaimValues.User.Delete;
    }

    public sealed class RolePolicy
    {
        public const string Create = ApplicationClaimValues.Role.Create;
        public const string View = ApplicationClaimValues.Role.View;
        public const string Delete = ApplicationClaimValues.Role.Delete;
        public const string UpdateRoleClaim = ApplicationClaimValues.Role.UpdateRoleClaim;
    }
}
