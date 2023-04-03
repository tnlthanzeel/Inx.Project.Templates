using Ardalis.Specification;
using Inexis.Clean.Architecture.Template.Application.Security.Filters;
using Microsoft.EntityFrameworkCore;
using VPMS.Domain.Entities.IdentityUserEntities;
using VPMS.SharedKernel;

namespace Inexis.Clean.Architecture.Template.Application.Security.Specs;

public sealed class UserFilterSpec : Specification<ApplicationUser>
{
    public UserFilterSpec(UserFilter filter)
    {
        Query.Where(u => u.Id != AppConstants.SuperAdmin.SuperUserId);

        Query.OrderBy(s => s.UserName);

        Query.Include(s => s.UserProfile);

        if (!string.IsNullOrWhiteSpace(filter.SearchQuery))
        {
            Query.Where(au => EF.Functions.Like(au.UserProfile.FirstName, "%" + filter.SearchQuery + "%") ||
                              EF.Functions.Like(au.UserProfile.LastName, "%" + filter.SearchQuery + "%") ||
                              EF.Functions.Like(au.UserName!, "%" + filter.SearchQuery + "%") ||
                              EF.Functions.Like(au.Email!, "%" + filter.SearchQuery + "%"));
        }
    }
}
