using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.Core.Security.Interfaces;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Inexis.Clean.Architecture.Template.Api.Controllers.V1.Security;

[Route("api/security/users/{userId}/profile")]
[ApiController]
public sealed class UserProfileController : AppControllerBase
{
    private readonly ISecurityService _securityService;

    public UserProfileController(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> ChangeUserPassword([FromRoute] Guid userId, [FromBody] UpdateUserPasswordDto model, CancellationToken token)
    {
        var response = await _securityService.ChangeUserPassword(userId, model, token);

        return response.Success ? NoContent() : UnsuccessfullResponse(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseResult<UserProfileDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserProfileById([FromRoute] Guid userId, CancellationToken token)
    {
        var response = await _securityService.GetUserProfile(userId, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUserProfile([FromRoute] Guid userId, [FromBody] UpdateUserProfileDto model, CancellationToken token)
    {
        var response = await _securityService.UpdateUserProfile(userId, model, token);

        return response.Success ? NoContent() : UnsuccessfullResponse(response);
    }
}


