using Inexis.Clean.Architecture.Template.Application.CommonInterfaces;
using Inexis.Clean.Architecture.Template.Application.PersistanceInterfaces;
using Inexis.Clean.Architecture.Template.Persistence.Repositories;
using Inexis.Clean.Architecture.Template.Persistence.Repositories.Security;
using Inexis.Clean.Architecture.Template.SharedKernal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Inexis.Clean.Architecture.Template.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString(AppConstants.Database.APIDbConnectionName))
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.TryAddScoped<IUserSecurityRespository, UserSecurityRespository>();
        services.TryAddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
