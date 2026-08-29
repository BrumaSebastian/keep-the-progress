using KTP.Shared.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KTP.Infrastructure.Events;

public sealed class EventProcessor<TEvent>(
    IEventBus eventBus,
    IDomainEventHandler<TEvent> handler,
    ILogger<EventProcessor<TEvent>> logger) : BackgroundService where TEvent : IDomainEvent
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var reader = eventBus.Subscribe<TEvent>(handler);

        await foreach (var @event in reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                logger.LogInformation("Processing event: {EventType}", typeof(TEvent).Name);
                await handler.Handle(@event, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing event: {EventType}", typeof(TEvent).Name);
            }
        }
    }
}
