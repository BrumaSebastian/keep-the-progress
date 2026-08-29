using KTP.Shared.Common;
using KTP.Shared.Contracts;

namespace KTP.Shared.DomainEvents.PlanItems;

public sealed class PlanItemAddedToDayEvent(Guid AggregateId, Guid TaskDayId, Guid PlanItemId, string ItemText, int SortOrder) 
    : DomainEvent(AggregateId, "TaskDay", Constants.DefaultUser)
{
}