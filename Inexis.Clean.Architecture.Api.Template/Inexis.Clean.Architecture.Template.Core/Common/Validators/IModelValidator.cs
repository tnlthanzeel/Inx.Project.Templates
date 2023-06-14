using FluentValidation.Results;

namespace Inexis.Clean.Architecture.Template.Core.Common.Validators;

public interface IModelValidator
{
    Task<ValidationResult> ValidateAsync<TValidator, TRequest>(TRequest request, CancellationToken token);
}