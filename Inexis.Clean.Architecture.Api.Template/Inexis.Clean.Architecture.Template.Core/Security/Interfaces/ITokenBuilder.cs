using Inexis.Clean.Architecture.Template.Core.Security.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Core.Security.Interfaces;

public interface ITokenBuilder
{
    Task<string> GenerateJwtTokenAsync(ApplicationUser user, CancellationToken token);
}
