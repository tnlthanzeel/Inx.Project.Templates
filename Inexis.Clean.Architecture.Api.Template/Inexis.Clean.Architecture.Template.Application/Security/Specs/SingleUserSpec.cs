using Ardalis.Specification;
using VPMS.Domain.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Application.Security.Specs;

internal sealed class SingleUserSpec : Specification<ApplicationUser>, ISingleResultSpecification
{
    public SingleUserSpec()
    {
        Query.Include(i => i.UserProfile)
                .ThenInclude(i => i.UserCompanies)
                    .ThenInclude(i => i.Company)
             .Include(i => i.UserProfile)
                .ThenInclude(i => i.UserNotificationSchedule);
    }
}
