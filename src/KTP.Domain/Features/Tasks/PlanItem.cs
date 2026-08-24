using KTP.Domain.Base;

namespace KTP.Domain.Features.Tasks;

public sealed class PlanItem : Entity, IModificationMetadata
{
    // Content
    public required string Text { get; set; }
    public int SortOrder { get; set; }
    public bool IsCompleted { get; set; }

    public DateTime? CompletedAtUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    // Navigation Properties
    public Guid TaskDayId { get; set; }
    public required TaskDay TaskDay { get; set; }
}