using KTP.Shared.Contracts;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace KTP.Infrastructure.Events;

public interface IEventBus
{
    Task Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    ChannelReader<TEvent> Subscribe<TEvent>(IDomainEventHandler<TEvent> handler) where TEvent : IDomainEvent;
}

public sealed class EventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, object> eventChannels = new();

    public async Task Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        var channel = GetOrCreateChannel<TEvent>();
        await channel.Writer.WriteAsync(@event);
    }

    public ChannelReader<TEvent> Subscribe<TEvent>(IDomainEventHandler<TEvent> handler) where TEvent : IDomainEvent
    {
        return GetOrCreateChannel<TEvent>().Reader;
    }

    private Channel<TEvent> GetOrCreateChannel<TEvent>() where TEvent : IDomainEvent
    {
        var eventType = typeof(TEvent);

        // ConcurrentDictionary.GetOrAdd is atomic - thread-safe
        var channel = eventChannels.GetOrAdd(
            eventType,
            _ => CreateChannel<TEvent>());

        return (Channel<TEvent>)channel;
    }

    private static Channel<TEvent> CreateChannel<TEvent>() where TEvent : IDomainEvent
    {
        var options = new BoundedChannelOptions(100)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        return Channel.CreateBounded<TEvent>(options);
    }
}
