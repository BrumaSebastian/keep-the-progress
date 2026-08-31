namespace KTP.Shared.Contracts;

public interface IDomainEvent : IBaseEvent
{
    Guid AggregateId { get; }
    string AggregateType { get; }
}

public abstract class DomainEvent(Guid aggregateId, string aggregateType, string occurredBy) : IDomainEvent
{
    public Guid EventId { get; private set; } = Guid.NewGuid();
    public DateTime OccurredOnUtc { get; private set; } = DateTime.UtcNow;
    public string OccurredBy { get; private set; } = occurredBy;
    public Guid AggregateId { get; private set; } = aggregateId;
    public string AggregateType { get; private set; } = aggregateType;
}