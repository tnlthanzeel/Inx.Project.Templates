using Ardalis.Specification;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;
using Inexis.Clean.Architecture.Template.SharedKernal.Models;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Inexis.Clean.Architecture.Template.Application.PersistanceInterfaces;

public interface IUserSecurityRespository : IBaseRepository
{
    Task<IReadOnlyList<UserClaimsDto>> GetUserClaims(Guid userId, CancellationToken token);

    Task<IReadOnlyList<string>> GetUserRoles(ApplicationUser user, CancellationToken token = default);

    Task<IReadOnlyList<Role>> GetAllRoles(CancellationToken token = default, bool asTracking = false, string? searchQuery = null);

    Task<bool> HasClaim(Guid userId, IEnumerable<string> claimValue, CancellationToken token = default);

    Task<ApplicationUser?> GetUser(ClaimsPrincipal user);

    Task<ApplicationUser?> FindByEmail(string email);

    Task<ResponseResult<UserDto>> CreateUser(string userName, string password, string email, string role, string firstName, string lastName, IEnumerable<Guid> companyIds, IEnumerable<string> permissions, string timeZone, CancellationToken token);

    Task<ApplicationUser?> GetUser(Guid id, CancellationToken token, bool asTracking = false);

    Task<bool> DoesRoleExists(string roleName, CancellationToken token);

    Task<(IReadOnlyList<ApplicationUser> list, int totalRecocrds)> GetUserListBySpec(Paginator paginator, ISpecification<ApplicationUser> specification, CancellationToken token, bool asTracking = false);

    Task<IReadOnlyList<UserAssignedRole>> GetUsersWithRoles(IEnumerable<Guid> userIds);

    Task<ResponseResult> UpdateIdentityUserUser(ApplicationUser user, string email, string role, IEnumerable<string> permissions, CancellationToken token);

    Task<ApplicationUser?> GetUserBySpec(Guid id, CancellationToken token, ISpecification<ApplicationUser> specification, bool asTracking = false);

    Task<Role?> GetRoleById(Guid id, CancellationToken token, bool asTracking = false);
    Task<ResponseResult<UserRoleDto>> CreateRole(string roleName, CancellationToken token);

    Task<ResponseResult> DeleteRole(Guid roleId, CancellationToken token);
    Task DeleteRoleClaimsForRole(Role userRole);

    IReadOnlyList<IdentityRoleClaim<Guid>> AddRoleClaimsForRole(Guid id, IEnumerable<string> permissions);

    Task<IReadOnlyList<UserClaim>> DeleteUserClaimsForRoleClaim(Role userRole);

    void AddUserClaimsForRoleClaims(IEnumerable<IdentityRoleClaim<Guid>> newRoleClaims, IEnumerable<Guid> userIds);

    Task<List<IdentityRoleClaim<Guid>>> GetRoleClaimsByRoleId(Guid roleId);

    Task MergeClaims(List<Guid> userIds, List<string> distinctPermissions);

    Task<IReadOnlyList<IdentityRoleClaim<Guid>>> GetRoleClaims(CancellationToken token);

    Task<ResponseResult> ChangeUserPassword(ApplicationUser user, string currentPassword, string newPassword, CancellationToken token = default);

    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);

    Task<bool> HasAccessToCompany(Guid userId, Guid companyId);

    Task<bool> HasAccessToCompanies(Guid userId, List<Guid> companyIds, CancellationToken cancellationToken = default);

    Task<TResult?> GetUserByIdWithProjectionSpec<TResult>(ISpecification<ApplicationUser, TResult> specification, CancellationToken token);

    Task<IReadOnlyList<UserKeyValue>> GetUsersForPermissionByCompanyId(Guid companyId, string? permission);
    Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    Task<ResponseResult> ResetPassword(ApplicationUser user, string decodedPasswrdResetToken, string newPassword);
}
