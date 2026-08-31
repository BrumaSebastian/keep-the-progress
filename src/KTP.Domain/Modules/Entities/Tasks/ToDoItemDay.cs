using KTP.Domain.Base;
using KTP.Domain.Modules.Entities.Tasks.Enums;

namespace KTP.Domain.Modules.Entities.Tasks;

public sealed class ToDoItemDay : Entity, IModificationMetadata
{
    public DateTime DateUtc { get; set; }
    public TaskDayStatus Status { get; set; }

    public DateTime? CompletedAtUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    // Navigation Properties
    public Guid ToDoItemId { get; set; }
    public required ToDoItem ToDoItem { get; set; }
    public ICollection<PlanItem> PlanItems { get; set; } = [];
    public ICollection<Note> Notes { get; set; } = [];
}