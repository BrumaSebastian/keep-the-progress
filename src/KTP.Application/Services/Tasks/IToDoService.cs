using KTP.Application.Models.Requests.Tasks.ToDoItems;
using KTP.Application.Models.Responses.Common;
using KTP.Application.Models.Responses.Tasks.ToDoItems;

namespace KTP.Application.Services.Tasks;

public interface IToDoService
{
    CreateToDoItemResult CreateToDoItem(CreateToDoItemRequest request);
    GetToDoItemResult GetToDoItem(GetToDoItemRequest request);
    CursorPaginatedResponse<GetToDoItemResponse, Guid> GetToDoItems();
}
