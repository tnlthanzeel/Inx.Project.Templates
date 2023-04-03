using Microsoft.AspNetCore.Authorization;

namespace Inexis.Clean.Architecture.Template.Api.Policies;

public interface IAuthPolicyApplyer
{
    void Apply(AuthorizationOptions options);
}
