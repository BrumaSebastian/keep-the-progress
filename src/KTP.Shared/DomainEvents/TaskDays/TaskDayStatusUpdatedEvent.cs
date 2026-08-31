using KTP.Shared.Common;
using KTP.Shared.Contracts;

namespace KTP.Shared.DomainEvents.TaskDays;

public sealed class TaskDayStatusUpdatedEvent(Guid AggregateId, Guid TaskDayId, Guid TaskId, string NewStatus, DateTime? CompletedAtUtc) 
    : DomainEvent(AggregateId, "TaskDay", Constants.DefaultUser)
{
}