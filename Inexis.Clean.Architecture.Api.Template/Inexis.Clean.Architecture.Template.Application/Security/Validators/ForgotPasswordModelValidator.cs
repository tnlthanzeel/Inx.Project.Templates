using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.CommonValidators;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

public sealed class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
{
    public ForgotPasswordModelValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email is required")
            .ValidateEmail();
    }
}
