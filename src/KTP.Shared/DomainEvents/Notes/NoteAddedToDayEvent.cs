using KTP.Shared.Common;
using KTP.Shared.Contracts;

namespace KTP.Shared.DomainEvents.Notes;

public sealed class NoteAddedToDayEvent(Guid AggregateId, Guid TaskDayId, Guid NoteId, string Content) 
    : DomainEvent(AggregateId, "TaskDay", Constants.DefaultUser)
{
}