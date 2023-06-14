using FluentValidation;
using Inexis.Clean.Architecture.Template.Core.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Core.Security.Validators;

public sealed class AuthenticateUserDtoValidator : AbstractValidator<AuthenticateUserDto>
{
    public AuthenticateUserDtoValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("{PropertyName} is required");
    }
}
