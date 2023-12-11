using Inexis.Clean.Architecture.Template.Core.Common.Interfaces;
using Inexis.Clean.Architecture.Template.Infrastructure.NotificationServices;
using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;
using Inexis.Clean.Architecture.Template.SharedKernal.Models;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Inexis.Clean.Architecture.Template.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            opt.NotificationPublisher = new TaskWhenAllPublisher();
            opt.NotificationPublisherType = typeof(TaskWhenAllPublisher);
        });

        services.TryAddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
