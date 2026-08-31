using Microsoft.EntityFrameworkCore;

namespace KTP.Application.Models.Responses.Common;

public sealed class PaginatedResponse<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public bool HasPreviousPage => PageNumber > 1; 
    public bool HasNextPage => PageNumber < TotalPages;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    private PaginatedResponse() { }

    public static PaginatedResponse<T> Create(
        List<T> items,
        int pageNumber,
        int pageSize,
        int totalCount)
    {
        return new PaginatedResponse<T>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public static async Task<PaginatedResponse<T>> CreateAsync(
       IQueryable<T> source,
       int pageNumber,
       int pageSize)
    {
        var totalCount = await source.CountAsync();
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Create(items, pageNumber, pageSize, totalCount);
    }

    public static PaginatedResponse<T> Empty()
    {
        return new PaginatedResponse<T>
        {
            Items = [],
            PageNumber = 1,
            PageSize = 0,
            TotalCount = 0
        };
    }
}


