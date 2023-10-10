using FluentValidation;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;
using Inexis.Clean.Architecture.Template.SharedKernal.Helpers;

namespace Inexis.Clean.Architecture.Template.Core.Security.Validators;

public sealed class UpdateUserProfileDtoValidator : AbstractValidator<UpdateUserProfileDto>
{
    public UpdateUserProfileDtoValidator()
    {
        RuleFor(f => f.FirstName)
                   .FirstNameValidation();

        RuleFor(f => f.LastName)
                   .LastNameValidation();

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
