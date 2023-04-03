using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.Application.Security.Validators;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

public sealed class UpdateRoleClaimsDtoValidator : AbstractValidator<UpdateRoleClaimsDto>
{
    public UpdateRoleClaimsDtoValidator()
    {
        RuleFor(r => r.Permissions)
                .AppPermissionValueValidation();
    }
}
