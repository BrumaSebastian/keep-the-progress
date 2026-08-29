using KTP.Domain.Base;

namespace KTP.Domain.Modules.Entities.Tasks;

public sealed class Note : Entity, IModificationMetadata
{
    public required string Content { get; set; }

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    // Navigation Properties
    public Guid ToDoItemDayId { get; set; }
    public required ToDoItemDay ToDoItemDay { get; set; }
}