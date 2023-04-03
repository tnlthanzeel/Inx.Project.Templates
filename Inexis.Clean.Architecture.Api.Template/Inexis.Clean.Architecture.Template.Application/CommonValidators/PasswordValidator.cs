using FluentValidation;

namespace Inexis.Clean.Architecture.Template.Application.CommonValidators;

public static class PasswordValidator
{
    public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string?> rule, string parameterName)
    {
        return rule
            .NotEmpty().WithMessage($"{parameterName} is required")
            .MinimumLength(6).WithMessage($"{parameterName} must be atleast 14 characters long");
    }
}
