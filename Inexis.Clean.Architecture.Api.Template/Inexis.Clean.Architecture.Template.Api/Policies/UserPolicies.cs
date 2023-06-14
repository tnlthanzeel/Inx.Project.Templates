﻿using Inexis.Clean.Architecture.Template.Api.PolicyRequriements.UserClaimRequirements;
using Inexis.Clean.Architecture.Template.Core.Claims;
using Inexis.Clean.Architecture.Template.Core.Security.AuthPolicies;
using Microsoft.AspNetCore.Authorization;

namespace Inexis.Clean.Architecture.Template.Api.Policies;

public sealed class UserPolicies : IAuthPolicyApplyer
{
    public void Apply(AuthorizationOptions options)
    {
        options.AddPolicy(ApplicationAuthPolicy.UserPolicy.Create,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.User.Create));
                        });

        options.AddPolicy(ApplicationAuthPolicy.UserPolicy.View,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.User.View));
                        });

        options.AddPolicy(ApplicationAuthPolicy.UserPolicy.Edit,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.User.Edit));
                        });

        options.AddPolicy(ApplicationAuthPolicy.UserPolicy.Delete,
                        policy =>
                        {
                            policy.Requirements.Add(new UserClaimRequirement(ApplicationClaimValues.User.Delete));
                        });
    }
}
