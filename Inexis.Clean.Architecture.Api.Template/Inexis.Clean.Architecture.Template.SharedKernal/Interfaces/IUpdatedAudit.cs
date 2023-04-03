namespace Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;

public interface IUpdatedAudit
{
    DateTimeOffset? UpdatedOn { get; set; }

    string? UpdatedBy { get; set; }
}
