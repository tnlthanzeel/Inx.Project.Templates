using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Application.Security.Interfaces;

public interface ITokenBuilder
{
    Task<string> GenerateJwtTokenAsync(ApplicationUser user, CancellationToken token);
}
