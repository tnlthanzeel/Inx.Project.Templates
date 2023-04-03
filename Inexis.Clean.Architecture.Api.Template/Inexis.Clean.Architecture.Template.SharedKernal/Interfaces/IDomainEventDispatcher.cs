using Inexis.Clean.Architecture.Template.SharedKernal.Models;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents, bool isPrePersistantDomainEvent);
}
