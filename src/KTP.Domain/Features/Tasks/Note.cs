using KTP.Domain.Base;

namespace KTP.Domain.Features.Tasks;

public sealed class Note : Entity, IModificationMetadata
{
    public string Content { get; set; }

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    // Navigation Properties
    public Guid TaskDayId { get; set; }
    public TaskDay TaskDay { get; set; }
}