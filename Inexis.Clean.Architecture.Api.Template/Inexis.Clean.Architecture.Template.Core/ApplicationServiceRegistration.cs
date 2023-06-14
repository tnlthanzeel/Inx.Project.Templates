using Inexis.Clean.Architecture.Template.Core.Security;
using Inexis.Clean.Architecture.Template.Core.Security.Interfaces;
using Inexis.Clean.Architecture.Template.SharedKernal.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Inexis.Clean.Architecture.Template.Core;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.TryAddScoped<IModelValidator, Validator>();

        services.TryAddScoped<ISecurityService, SecurityService>();
        services.TryAddScoped<ITokenBuilder, TokenBuilder>();
        services.TryAddScoped<IPermissionService, PermissionService>();
        services.TryAddScoped<IUserRoleService, UserRoleService>();
        services.TryAddScoped<IUserRolePermissionFacadeService, UserRolePermissionFacadeService>();

        return services;
    }
}
