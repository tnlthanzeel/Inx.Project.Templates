using AutoMapper;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;

namespace Inexis.Clean.Architecture.Template.Application.AutomapperProfiles;

public sealed class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<ApplicationUser, UserSummaryDto>()
            .ForMember(d => d.FirstName, s => s.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(d => d.LastName, s => s.MapFrom(src => src.UserProfile.LastName));
    }
}
