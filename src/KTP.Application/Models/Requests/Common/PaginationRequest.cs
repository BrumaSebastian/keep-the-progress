namespace KTP.Application.Models.Requests.Common;

public sealed class PaginationRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public bool IsValid => PageNumber >= 1 && PageSize >= 1 && PageSize <= 100;
}
