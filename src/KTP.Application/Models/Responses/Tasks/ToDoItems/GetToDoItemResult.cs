using KTP.Application.Base.Errors;

namespace KTP.Application.Models.Responses.Tasks.ToDoItems;

public readonly union GetToDoItemResult(GetToDoItemResponse, NotFoundError);

public sealed record GetToDoItemResponse
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int SortOrder { get; set; }
}