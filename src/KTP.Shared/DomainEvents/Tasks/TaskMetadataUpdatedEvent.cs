using KTP.Shared.Common;
using KTP.Shared.Contracts;

namespace KTP.Shared.DomainEvents.Tasks;

public sealed class TaskMetadataUpdatedEvent(Guid AggregateId, Guid TaskId, string NewName, string NewDescription) 
    : DomainEvent(AggregateId, "Task", Constants.DefaultUser)
{
}