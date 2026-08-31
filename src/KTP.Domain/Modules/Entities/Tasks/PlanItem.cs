using KTP.Domain.Base;

namespace KTP.Domain.Modules.Entities.Tasks;

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
    public Guid ToDoItemDayId { get; set; }
    public required ToDoItemDay ToDoItemDay { get; set; }
}