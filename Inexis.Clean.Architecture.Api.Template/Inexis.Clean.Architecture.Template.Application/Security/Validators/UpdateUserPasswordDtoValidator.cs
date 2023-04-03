using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using VPMS.Application.CommonValidators;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

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
