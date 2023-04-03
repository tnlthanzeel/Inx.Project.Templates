using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.Application.Security.Interfaces;
using Inexis.Clean.Architecture.Template.Application.Security.Validators;
using Microsoft.AspNetCore.Identity;
using VPMS.Application.PersistanceInterfaces;
using VPMS.Domain.Entities.IdentityUserEntities;
using VPMS.SharedKernel.Exceptions;

namespace Inexis.Clean.Architecture.Template.Application.Security
{
    public sealed class UserRolePermissionFacadeService : IUserRolePermissionFacadeService
    {
        private readonly IModelValidator _validator;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserSecurityRespository _userSecurityRespository;

        public UserRolePermissionFacadeService(IModelValidator validator, RoleManager<Role> roleManager, IUserSecurityRespository userSecurityRespository)
        {
            _validator = validator;
            _roleManager = roleManager;
            _userSecurityRespository = userSecurityRespository;
        }

        public async Task<ResponseResult> UpdateRoleClaim(Guid roleId, UpdateRoleClaimsDto model, CancellationToken token)
        {
            var validationResult = await _validator.ValidateAsync<UpdateRoleClaimsDtoValidator, UpdateRoleClaimsDto>(model, token);

            if (validationResult.IsValid is false) return new ResponseResult(validationResult.Errors);

            var role = await _userSecurityRespository.GetRoleById(roleId, token);

            if (role is null) return new ResponseResult(new BadRequestException(nameof(roleId), $"Invalid role id ({roleId})"));

            var removedUserClaims = await _userSecurityRespository.DeleteUserClaimsForRoleClaim(role);

            await _userSecurityRespository.DeleteRoleClaimsForRole(role);

            var distinctPermissions = model.Permissions.Distinct().ToList();

            var newRoleClaims = _userSecurityRespository.AddRoleClaimsForRole(role.Id, distinctPermissions);

            await _userSecurityRespository.SaveChangesAsync(token);

            var userIds = removedUserClaims.Select(s => s.UserId).Distinct().ToList();

            _userSecurityRespository.AddUserClaimsForRoleClaims(newRoleClaims, userIds);

            await _userSecurityRespository.MergeClaims(userIds, distinctPermissions);

            await _userSecurityRespository.SaveChangesAsync(token);

            return new ResponseResult();
        }
    }
}
