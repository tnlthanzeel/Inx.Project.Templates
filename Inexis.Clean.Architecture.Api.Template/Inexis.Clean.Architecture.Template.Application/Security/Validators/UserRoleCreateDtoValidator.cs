﻿using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using VPMS.Application.PersistanceInterfaces;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

public sealed class UserRoleCreateDtoValidator : AbstractValidator<UserRoleCreateDto>
{
    public UserRoleCreateDtoValidator(IUserSecurityRespository userSecurityRespository)
    {
        RuleFor(r => r.RoleName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Role is required")
            .MaximumLength(256).WithMessage("Role name must be less than 256 character")
            .MustAsync(async (roleName, cancellation) =>
            {
                bool doesRoleExist = await userSecurityRespository.DoesRoleExists(roleName, cancellation);
                return !doesRoleExist;
            }).WithMessage(w => $"Role name ({w.RoleName}) already exists");

    }
}
