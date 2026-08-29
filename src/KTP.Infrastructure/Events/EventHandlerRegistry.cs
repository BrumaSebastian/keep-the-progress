using KTP.Shared.Contracts;
using System.Collections.Concurrent;

namespace KTP.Infrastructure.Events;

public interface IEventHandlerRegistry
{
    void Register<TEvent, THandler>(THandler handler)
        where TEvent : IDomainEvent
        where THandler : IDomainEventHandler<TEvent>;

    IReadOnlyList<object> GetHandlers<TEvent>() where TEvent : IDomainEvent;
}

public sealed class EventHandlerRegistry : IEventHandlerRegistry
{
    private readonly ConcurrentDictionary<Type, ConcurrentBag<object>> handlers = new();

    public void Register<TEvent, THandler>(THandler handler)
        where TEvent : IDomainEvent
        where THandler : IDomainEventHandler<TEvent>
    {
        var eventType = typeof(TEvent);

        handlers.AddOrUpdate(
            eventType,
            new ConcurrentBag<object> { handler },
            (_, bag) =>
            {
                bag.Add(handler);
                return bag;
            });
    }

    public IReadOnlyList<object> GetHandlers<TEvent>() where TEvent : IDomainEvent
    {
        var eventType = typeof(TEvent);

        if (handlers.TryGetValue(eventType, out var bag))
        {
            return bag.ToList().AsReadOnly();
        }

        return Array.Empty<object>();
    }
}
