using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;

namespace Inexis.Clean.Architecture.Template.Core.Security.Interfaces;

public interface IUserRolePermissionFacadeService
{
    Task<ResponseResult> UpdateRoleClaim(Guid roleId, UpdateRoleClaimsDto model, CancellationToken token);
}
