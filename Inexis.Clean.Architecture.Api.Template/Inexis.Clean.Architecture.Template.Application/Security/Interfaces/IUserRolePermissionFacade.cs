﻿using Inexis.Clean.Architecture.Template.Application.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Application.Security.Interfaces;

public interface IUserRolePermissionFacadeService
{
    Task<ResponseResult> UpdateRoleClaim(Guid roleId, UpdateRoleClaimsDto model, CancellationToken token);
}
