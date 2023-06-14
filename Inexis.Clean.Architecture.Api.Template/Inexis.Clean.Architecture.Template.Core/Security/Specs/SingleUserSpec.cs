using Ardalis.Specification;
using Inexis.Clean.Architecture.Template.Core.Security.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Core.Security.Specs;

internal sealed class SingleUserSpec : Specification<ApplicationUser>
{
    public SingleUserSpec()
    {
        Query.Include(i => i.UserProfile);
    }
}
