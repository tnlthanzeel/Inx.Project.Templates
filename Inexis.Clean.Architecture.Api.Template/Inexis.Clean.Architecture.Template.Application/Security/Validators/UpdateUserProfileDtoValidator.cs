using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using Inexis.Clean.Architecture.Template.SharedKernal.Extensions;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

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
                var isValidTimeZone = TimeZoneExtension.IsTimeZoneAvailable(timeZone);
                return isValidTimeZone;
            }).WithMessage("Invalid Time zone");
    }
}
