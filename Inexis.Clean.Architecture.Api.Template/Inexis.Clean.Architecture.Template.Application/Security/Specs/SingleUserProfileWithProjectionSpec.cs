using Ardalis.Specification;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Application.Security.Specs;

public sealed class SingleUserProfileWithProjectionSpec : Specification<ApplicationUser, UserProfileDto>
{
    public SingleUserProfileWithProjectionSpec(Guid userId)
    {
        Query.Where(u => u.Id == userId);

        Query.Select(s => new UserProfileDto()
        {
            Id = s.Id,
            Email = s.Email!,
            UserName = s.UserName!,
            FirstName = s.UserProfile.FirstName,
            LastName = s.UserProfile.LastName,
            TimeZone = s.UserProfile.TimeZone,
        });
    }
}
