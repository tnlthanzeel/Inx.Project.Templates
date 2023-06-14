using Inexis.Clean.Architecture.Template.Core.Claims;
using Inexis.Clean.Architecture.Template.SharedKernal;
using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;
using System.Security.Claims;

namespace Inexis.Clean.Architecture.Template.Api.Services;

public sealed class LoggedInUserService : ILoggedInUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static readonly string _emptyUserId = Guid.Empty.ToString();

    public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? _emptyUserId;

        UserEmail = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Email)?.Value;

        _httpContextAccessor = httpContextAccessor;

        UserTimeZone = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(f => f.Type == CustomClaimTypes.UserTimeZone)?.Value;

        UserRole = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Role)?.Value;
    }

    public string UserId { get; }

    public string? UserEmail { get; }

    public string? UserTimeZone { get; }

    public string? UserRole { get; }

    public bool IsAdminUser() => UserRole == AppConstants.Administrator.RoleName;
}
