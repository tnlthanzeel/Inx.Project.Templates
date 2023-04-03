using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Validators;

public sealed class Validator : IModelValidator
{
    private readonly IServiceProvider _serviceProvider;

    public Validator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<ValidationResult> ValidateAsync<TValidator, TRequest>(TRequest request, CancellationToken token)
    {
        var validator = ActivatorUtilities.CreateInstance<TValidator>(_serviceProvider) as AbstractValidator<TRequest>;

        var validationResult = await validator!.ValidateAsync(request, cancellation: token);

        return validationResult;
    }
}
