using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.Core.Security.Interfaces;
using Inexis.Clean.Architecture.Template.Core.Security.ModulePermissions;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inexis.Clean.Architecture.Template.Api.Controllers.V1.Security;

[Route("api/security")]
public sealed class SecurityController : AppControllerBase
{
    private readonly ISecurityService _securityService;

    public SecurityController(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    /// <summary>
    /// Authenticate a user by providing the username and password
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A Respoonse result object conataining the authenticated user info</returns>
    [AllowAnonymous]
    [HttpPost("authenticate")]
    [ProducesResponseType(typeof(ResponseResult<AuthenticatedUserDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Authenticate([FromBody] AuthenticateUserDto model, CancellationToken token)
    {
        var response = await _securityService.AuthenticateUser(model, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpGet("app-permissions")]
    [ProducesResponseType(typeof(ResponseResult<IReadOnlyList<KeyValuePair<string, IReadOnlyList<PermissionSet>>>>), StatusCodes.Status200OK)]
    public ActionResult GeApplicationPermissions()
    {
        var permissionList = AppModulePermissions.GetPermissionList();

        var response = new ResponseResult<IReadOnlyList<KeyValuePair<string, IReadOnlyList<PermissionSet>>>>(permissionList, permissionList.Count);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("forgot-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> SendPasswordResetEmail([FromBody] ForgotPasswordModel forgotPasswordModel, CancellationToken token)
    {
        var response = await _securityService.SendResetPasswordEmail(forgotPasswordModel, token);

        return response.Success ? Ok() : UnsuccessfullResponse(response);
    }

    [AllowAnonymous]
    [HttpPost("reset-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto model, CancellationToken token)
    {
        var response = await _securityService.ResetPassword(model, token);

        return response.Success ? Ok() : UnsuccessfullResponse(response);
    }
}
