using FluentValidation;
using Inexis.Clean.Architecture.Template.Core.Common.Validators;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.Core.Security.Interfaces;
using Inexis.Clean.Architecture.Template.SharedKernal.Helpers;

namespace Inexis.Clean.Architecture.Template.Core.Security.Validators;

public sealed class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator(IUserSecurityRespository userSecurityRespository)
    {
        RuleFor(f => f.FirstName)
                   .FirstNameValidation();

        RuleFor(f => f.LastName)
                   .LastNameValidation();

        RuleFor(f => f.Email)
            .NotEmpty().WithMessage("Email is required")
            .ValidateEmail();

        RuleFor(r => r.Role)
           .NotEmpty().WithMessage("Role is required");

        RuleFor(r => r.Permissions)
            .AppPermissionValueValidation();

        RuleFor(r => r.Role)
         .AppRoleValidation(userSecurityRespository);

        RuleFor(f => f.TimeZone)
          .Cascade(CascadeMode.Stop)
          .NotEmpty().WithMessage("TimeZone is required")
          .Must((model, timeZone) =>
          {
              var isValidTimeZone = TimeZoneHelper.IsTimeZoneAvailable(timeZone);
              return isValidTimeZone;
          }).WithMessage("Invalid Time zone");
    }
}
