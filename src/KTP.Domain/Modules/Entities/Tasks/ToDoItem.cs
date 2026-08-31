using KTP.Domain.Base;

namespace KTP.Domain.Modules.Entities.Tasks;

public sealed class ToDoItem : Entity, IAuditMetadata
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int SortOrder { get; set; }

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }

    // Navigation Propeties
    public ICollection<ToDoItemDay> ToDoItemDays { get; set; } = [];
}