namespace KTP.Application.Models.Requests.Tasks.ToDoItems;

public sealed record CreateToDoItemRequest(string Name, string? Description);