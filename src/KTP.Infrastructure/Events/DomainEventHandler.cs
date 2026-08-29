using KTP.Shared.Contracts;

namespace KTP.Infrastructure.Events;

public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent @event, CancellationToken cancellationToken = default);
}

public abstract class DomainEventHandler<TEvent> : IDomainEventHandler<TEvent> where TEvent : IDomainEvent
{
    protected readonly IEventBus EventBus;

    protected DomainEventHandler(IEventBus eventBus)
    {
        EventBus = eventBus;
    }

    public abstract Task Handle(TEvent @event, CancellationToken cancellationToken = default);
}
