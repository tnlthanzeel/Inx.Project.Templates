using FluentValidation;
using Inexis.Clean.Architecture.Template.Core.CommonValidators;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Core.Security.Validators;

public sealed class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
{
    public ForgotPasswordModelValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email is required")
            .ValidateEmail();
    }
}
