using Inexis.Clean.Architecture.Template.Core.Security.AuthPolicies;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.Core.Security.Interfaces;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inexis.Clean.Architecture.Template.Api.Controllers.V1.Security;

[Route("api/security/roles")]
[ApiController]
public sealed class RolesController : AppControllerBase
{
    private readonly IUserRoleService _userRoleService;
    private readonly IUserRolePermissionFacadeService _userRolePermissionFacadeService;

    public RolesController(IUserRoleService userRoleService, IUserRolePermissionFacadeService userRolePermissionFacadeService)
    {
        _userRoleService = userRoleService;
        _userRolePermissionFacadeService = userRolePermissionFacadeService;
    }

    [HttpPost]
    [Authorize(policy: ApplicationAuthPolicy.RolePolicy.Create)]
    [ProducesResponseType(typeof(ResponseResult<UserRoleDto>), StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateRoleAsync([FromBody] UserRoleCreateDto model, CancellationToken token)
    {
        var response = await _userRoleService.CreateRole(model, token);

        return response.Success ? CreatedAtRoute(nameof(GetRole), new { id = response.Data!.RoleId }, response) : UnsuccessfullResponse(response);
    }

    [HttpGet]
    [Authorize(policy: ApplicationAuthPolicy.RolePolicy.View)]
    [ProducesResponseType(typeof(ResponseResult<IReadOnlyList<UserRoleDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetRoleList([FromQuery] string? searchQuery, CancellationToken token)
    {
        var response = await _userRoleService.GetAllRoles(searchQuery, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpGet("{id}", Name = "GetRole")]
    [Authorize(policy: ApplicationAuthPolicy.RolePolicy.View)]
    [ProducesResponseType(typeof(ResponseResult<UserRoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetRole([FromRoute] Guid id, CancellationToken token)
    {
        var response = await _userRoleService.GetById(id, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpDelete("{id}")]
    [Authorize(policy: ApplicationAuthPolicy.RolePolicy.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteRole([FromRoute] Guid id, CancellationToken token)
    {
        var response = await _userRoleService.Delete(id, token);

        return response.Success ? NoContent() : UnsuccessfullResponse(response);
    }

    [HttpPut("{roleId}/permission-templates")]
    [Authorize(policy: ApplicationAuthPolicy.RolePolicy.UpdateRoleClaim)]
    [ProducesResponseType(typeof(ResponseResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateRoleClaims(Guid roleId, [FromBody] UpdateRoleClaimsDto model, CancellationToken token)
    {
        var response = await _userRolePermissionFacadeService.UpdateRoleClaim(roleId, model, token);

        return response.Success ? NoContent() : UnsuccessfullResponse(response);
    }

    [HttpGet("permission-templates")]
    [ProducesResponseType(typeof(ResponseResult<IReadOnlyList<PermissionTemplateDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetRoleClaimTemplates(CancellationToken token)
    {
        var response = await _userRoleService.GetRoleClaimTemplates(token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpGet("{roleId}/permission-templates")]
    [ProducesResponseType(typeof(ResponseResult<PermissionTemplateDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetRoleClaimTemplates(Guid roleId, CancellationToken token)
    {
        var response = await _userRoleService.GetRoleClaimTemplate(roleId, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }
}
