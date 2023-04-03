using FluentValidation;
using VPMS.Application.PersistanceInterfaces.Settings;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

public static class UserCompaniesValidator
{
    public static IRuleBuilderOptions<T, IEnumerable<Guid>> UserAssignedCompanyValidation<T>(this IRuleBuilderInitial<T, IEnumerable<Guid>> rule, ICompanyRepository companyRepository)
    {
        return rule
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("CompanIds cannot be null")
                .NotEmpty().WithMessage("CompanIds cannot be an empty list")
                .Must(companyIds => companyIds.All(companyId => Guid.Empty != companyId))
                    .WithMessage("CompanIds cannot contain empty guids")
                 .MustAsync(async (companyIds, cancellation) =>
                 {
                     bool areCompanyIdsValid = await companyRepository.DoesAllCompanyIdsExists(companyIds, cancellation);
                     return areCompanyIdsValid;
                 }).WithMessage("Some companyIds does not exists");
    }
}
