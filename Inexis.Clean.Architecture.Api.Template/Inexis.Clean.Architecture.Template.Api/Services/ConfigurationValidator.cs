using Inexis.Clean.Architecture.Template.Core.Security;

namespace Inexis.Clean.Architecture.Template.Api.Services;

internal sealed class ConfigurationValidator
{
    public static void ValidateConfigurations(IServiceCollection services)
    {
        services.AddOptions<JwtConfig>()
                .BindConfiguration(nameof(JwtConfig))
                .ValidateDataAnnotations()
                .ValidateOnStart();
    }
}
