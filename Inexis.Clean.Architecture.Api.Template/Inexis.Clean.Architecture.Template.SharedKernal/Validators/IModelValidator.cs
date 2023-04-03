using FluentValidation.Results;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Validators;

public interface IModelValidator
{
    Task<ValidationResult> ValidateAsync<TValidator, TRequest>(TRequest request, CancellationToken token);
}