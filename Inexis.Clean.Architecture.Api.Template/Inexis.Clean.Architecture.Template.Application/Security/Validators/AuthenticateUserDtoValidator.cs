using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

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
