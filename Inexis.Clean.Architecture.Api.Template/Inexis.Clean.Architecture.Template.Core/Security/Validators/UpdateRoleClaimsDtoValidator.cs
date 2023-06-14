using FluentValidation;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Core.Security.Validators;

public sealed class UpdateRoleClaimsDtoValidator : AbstractValidator<UpdateRoleClaimsDto>
{
    public UpdateRoleClaimsDtoValidator()
    {
        RuleFor(r => r.Permissions)
                .AppPermissionValueValidation();
    }
}
