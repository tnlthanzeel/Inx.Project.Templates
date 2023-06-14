namespace Inexis.Clean.Architecture.Template.Core.CommonDtos;

public sealed class EmailModel
{
    public string Body { get; init; } = null!;
    public string To { get; init; } = null!;
    public string Subject { get; init; } = null!;
}
