using KTP.Shared.Common;
using KTP.Shared.Contracts;

namespace KTP.Shared.DomainEvents.PlanItems;

public sealed class PlanItemCompletedEvent(Guid AggregateId, Guid TaskDayId, Guid PlanItemId, DateTime CompletionDate) 
    : DomainEvent(AggregateId, "TaskDay", Constants.DefaultUser)
{
}