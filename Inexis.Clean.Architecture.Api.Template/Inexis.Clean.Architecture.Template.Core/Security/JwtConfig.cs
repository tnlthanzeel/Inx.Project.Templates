using System.ComponentModel.DataAnnotations;

namespace Inexis.Clean.Architecture.Template.Core.Security;

public sealed class JwtConfig
{

    [Required]
    public string Issuer { get; set; } = null!;
    [Required]
    public string Audience { get; set; } = null!;
    [Required]
    public string SigningKey { get; set; } = null!;
    [Required]
    public TimeSpan TokenLifetime { get; set; }
}