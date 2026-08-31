using KTP.Application.Base.Errors;

namespace KTP.Application.Models.Responses.Tasks.ToDoItems;

public readonly union CreateToDoItemResult(Guid, CreateError);