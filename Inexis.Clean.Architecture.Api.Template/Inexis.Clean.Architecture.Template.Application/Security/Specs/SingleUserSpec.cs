using Ardalis.Specification;
using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Application.Security.Specs;

internal sealed class SingleUserSpec : Specification<ApplicationUser>, ISingleResultSpecification
{
    public SingleUserSpec()
    {
        Query.Include(i => i.UserProfile);
    }
}
