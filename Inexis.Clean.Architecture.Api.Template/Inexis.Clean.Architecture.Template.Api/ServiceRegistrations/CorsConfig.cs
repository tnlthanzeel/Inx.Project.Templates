﻿namespace Inexis.Clean.Architecture.Template.Api.ServiceRegistrations;

internal static class CorsConfig
{
    public static IServiceCollection AddCorsConfig(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        return services;
    }
}
