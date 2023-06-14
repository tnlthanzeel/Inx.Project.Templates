using FluentValidation;
using Inexis.Clean.Architecture.Template.Core.Common.Validators;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Core.Security.Validators;

public sealed class UpdateUserPasswordDtoValidator : AbstractValidator<UpdateUserPasswordDto>
{
    public UpdateUserPasswordDtoValidator()
    {
        RuleFor(r => r.CurrentPassword)
            .NotEmpty().WithMessage("Current Password is required");

        RuleFor(r => r.NewPassword)
            .ValidatePassword(nameof(UpdateUserPasswordDto.NewPassword))
            .Equal(r => r.ConfirmPassword).WithMessage("New Password and Confirm Password does not match");
    }
}
