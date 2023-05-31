using Inexis.Clean.Architecture.Template.Api.PolicyRequriements.UserClaimRequirements;
using Inexis.Clean.Architecture.Template.Domain.AuthPolicies;
using Inexis.Clean.Architecture.Template.Domain.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Inexis.Clean.Architecture.Template.Api.Policies;

public sealed class RolePolicies : IAuthPolicyApplyer
{
    public void Apply(AuthorizationOptions options)
    {
        options.AddPolicy(ApplicationAuthPolicy.RolePolicy.Create,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.Role.Create));
                        });

        options.AddPolicy(ApplicationAuthPolicy.RolePolicy.View,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.Role.View, ApplicationClaimValues.User.Create,
                                                                             ApplicationClaimValues.User.Edit));
                        });

        options.AddPolicy(ApplicationAuthPolicy.RolePolicy.UpdateRoleClaim,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.Role.UpdateRoleClaim));
                        });

        options.AddPolicy(ApplicationAuthPolicy.RolePolicy.Delete,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.Role.Delete));
                        });
    }
}
