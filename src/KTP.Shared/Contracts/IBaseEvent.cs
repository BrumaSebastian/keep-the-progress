namespace KTP.Shared.Contracts;

public interface IBaseEvent
{
    Guid EventId { get; }
    DateTime OccurredOnUtc { get; }
    string OccurredBy { get; }
}