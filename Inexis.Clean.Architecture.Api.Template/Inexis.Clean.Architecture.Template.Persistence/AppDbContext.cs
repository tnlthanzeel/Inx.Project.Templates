using Inexis.Clean.Architecture.Template.Domain.Entities.IdentityUserEntities;
using Inexis.Clean.Architecture.Template.Persistence.AuditSetup;
using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inexis.Clean.Architecture.Template.Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser, Role, Guid, UserClaim, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IDomainEventDispatcher? _dispatcher;

    public AppDbContext(DbContextOptions<AppDbContext> options, ILoggedInUserService loggedInUserService, IDomainEventDispatcher? dispatcher) : base(options)
    {
        _loggedInUserService = loggedInUserService;
        _dispatcher = dispatcher;
        SavingChanges += ModifyAuditInformation;
    }

    private void ModifyAuditInformation(object? sender, SavingChangesEventArgs e)
    {
        ChangeTracker.DetectChanges();

        List<Audit> auditEntries = new();
        var auditTable = Set<Audit>();

        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;

            if (entity is ICreatedAudit createdEntry && entry.State == EntityState.Added)
            {
                createdEntry.CreatedOn = DateTimeOffset.UtcNow;
                createdEntry.CreatedBy = _loggedInUserService.UserId;
            }

            else if (entity is IDeletedAudit deletedentry and { IsDeleted: true })
            {
                deletedentry.DeletedOn = DateTimeOffset.UtcNow;
                deletedentry.DeletedBy = _loggedInUserService.UserId;
            }

            else if (entity is IUpdatedAudit updatedEntry && entry.State == EntityState.Modified)
            {
                updatedEntry.UpdatedOn = DateTimeOffset.UtcNow;
                updatedEntry.UpdatedBy = _loggedInUserService.UserId;
            }

            var audit = OnBeforeSaveChanges(entry, ContextId.InstanceId);

            if (audit is not null) auditEntries.Add(audit);
        }

        auditTable.AddRange(auditEntries);
    }

    private Audit? OnBeforeSaveChanges(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, Guid batchId)
    {
        if (entry.Entity is INoAudit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged) return default;

        var auditEntry = new AuditEntry(entry, batchId)
        {
            TableName = entry.Entity.GetType().Name,
            UserId = _loggedInUserService.UserId
        };

        foreach (var property in entry.Properties)
        {
            string propertyName = property.Metadata.Name;
            if (property.Metadata.IsPrimaryKey())
            {
                auditEntry.PrimaryKey = property.CurrentValue!.ToString()!;
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.AuditType = AuditType.Create;
                    auditEntry.NewValues[propertyName] = property.CurrentValue!;
                    break;

                case EntityState.Deleted:
                    auditEntry.AuditType = AuditType.Delete;
                    auditEntry.OldValues[propertyName] = property.OriginalValue!;
                    break;

                case EntityState.Modified:
                    if (property.IsModified)
                    {
                        auditEntry.ChangedColumns.Add(propertyName);
                        auditEntry.AuditType = AuditType.Update;
                        auditEntry.OldValues[propertyName] = property.OriginalValue!;
                        auditEntry.NewValues[propertyName] = property.CurrentValue!;
                    }
                    break;
            }
        }

        return auditEntry.ToAudit();
    }
}
