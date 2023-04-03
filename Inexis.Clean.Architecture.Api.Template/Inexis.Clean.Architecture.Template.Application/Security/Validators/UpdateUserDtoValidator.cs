using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.Application.Security.Validators;
using VPMS.Application.CommonValidators;
using VPMS.Application.PersistanceInterfaces;
using VPMS.Application.PersistanceInterfaces.Settings;
using VPMS.Application.Security.Validators;
using VPMS.SharedKernel.Helpers;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

public sealed class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator(IUserSecurityRespository userSecurityRespository, ICompanyRepository companyRepository)
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

        RuleFor(r => r.CompanyIds)
            .UserAssignedCompanyValidation(companyRepository);

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
