using KTP.Domain.Base;
using KTP.Domain.Features.Tasks.Enums;

namespace KTP.Domain.Features.Tasks;

public sealed class TaskDay : Entity, IModificationMetadata
{
    public DateTime DateUtc { get; set; }
    public TaskDayStatus Status { get; set; }

    public DateTime? CompletedAtUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    // Navigation Properties
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    public ICollection<PlanItem> PlanItems { get; set; } = [];
    public ICollection<Note> Notes { get; set; } = [];
}