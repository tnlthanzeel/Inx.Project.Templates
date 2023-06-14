namespace Inexis.Clean.Architecture.Template.Core.CommonDtos;

public record AddressDto
{
    public string? Address { get; init; }

    public string? City { get; init; }

    public string? Province { get; init; }

    public string? State { get; init; }

    public string? PostalCode { get; init; }
}
