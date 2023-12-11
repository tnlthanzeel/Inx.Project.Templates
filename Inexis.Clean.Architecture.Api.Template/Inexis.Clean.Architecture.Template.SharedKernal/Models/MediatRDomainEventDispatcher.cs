using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;
using MediatR;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Models;

public sealed class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public MediatRDomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents, bool isPrePersistantDomainEvent)
    {
        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.DomainEvents.Where(w => w.IsPrePersistantDomainEvent == isPrePersistantDomainEvent).ToArray();
            entity.ClearDomainEvents(isPrePersistantDomainEvent);
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}
