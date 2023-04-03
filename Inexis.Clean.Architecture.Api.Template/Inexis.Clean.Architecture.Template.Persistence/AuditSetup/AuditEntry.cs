using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Inexis.Clean.Architecture.Template.Persistence.AuditSetup;

internal sealed class AuditEntry
{
    public AuditEntry(EntityEntry entry, Guid batchId)
    {
        Entry = entry;
        BatchId = batchId;
    }
    public EntityEntry Entry { get; }
    public string? UserId { get; set; }
    public string TableName { get; set; } = null!;
    public string? PrimaryKey { get; set; }
    public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
    public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
    public AuditType AuditType { get; set; }
    public List<string> ChangedColumns { get; } = new List<string>();
    public Guid BatchId { get; }


    internal Audit ToAudit()
    {
        var audit = new Audit
        {
            BatchId = BatchId,
            UserId = UserId,
            AuditType = AuditType,
            TableName = TableName,
            CreatedOn = DateTimeOffset.UtcNow,
            PrimaryKey = PrimaryKey!,
            OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
            AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns),
        };
        return audit;
    }
}
