using Inexis.Clean.Architecture.Template.Core.Security.AuthPolicies;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.Core.Security.Filters;
using Inexis.Clean.Architecture.Template.Core.Security.Interfaces;
using Inexis.Clean.Architecture.Template.SharedKernal.Models;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inexis.Clean.Architecture.Template.Api.Controllers.V1.Security;

[Route("api/security/users")]
[ApiController]
public sealed class UsersController : AppControllerBase
{
    private readonly ISecurityService _securityService;

    public UsersController(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    [HttpPost]
    [Authorize(policy: ApplicationAuthPolicy.UserPolicy.Create)]
    [ProducesResponseType(typeof(ResponseResult<UserDto>), StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateUser([FromBody] UserCreateDto model, CancellationToken token)
    {
        var response = await _securityService.CreateUser(model, token);

        return response.Success ? CreatedAtRoute(nameof(GetUserById), new { id = response.Data!.Id }, response) : UnsuccessfullResponse(response);
    }

    /// <summary>
    /// Get a user by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetUserById")]
    [Authorize(policy: ApplicationAuthPolicy.UserPolicy.View)]
    [ProducesResponseType(typeof(ResponseResult<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserById([FromRoute] Guid id, CancellationToken token)
    {
        var response = await _securityService.GetUser(id, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpGet]
    [Authorize(policy: ApplicationAuthPolicy.UserPolicy.View)]
    [ProducesResponseType(typeof(ResponseResult<IReadOnlyList<UserSummaryDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetUserList([FromQuery] Paginator paginator, [FromQuery] UserFilter filter, CancellationToken token)
    {
        var response = await _securityService.GetList(paginator, filter, token);

        return response.Success ? Ok(response) : UnsuccessfullResponse(response);
    }

    [HttpPut("{id}")]
    [Authorize(policy: ApplicationAuthPolicy.UserPolicy.Edit)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto model, CancellationToken token)
    {
        var response = await _securityService.UpdateUser(id, model, token);

        return response.Success ? NoContent() : UnsuccessfullResponse(response);
    }

    [HttpDelete("{id}")]
    [Authorize(policy: ApplicationAuthPolicy.UserPolicy.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid id, CancellationToken token)
    {
        var response = await _securityService.DeleteUser(id, token);

        return response.Success ? NoContent() : UnsuccessfullResponse(response);
    }
}
