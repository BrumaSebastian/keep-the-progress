namespace KTP.Application.Models.Responses.Common;

public sealed class CursorPaginatedResponse<T, TId> where TId : struct, IEquatable<TId>
{
    public List<T> Items { get; set; } = [];
    public TId? NextCursor { get; set; }
    public TId? PreviousCursor { get; set; }
    public int? TotalCount { get; set; }
    public bool HasNextPage => NextCursor.HasValue;
    public bool HasPreviousPage => PreviousCursor.HasValue;

    private CursorPaginatedResponse() { }

    public static CursorPaginatedResponse<T, TId> Create(
        List<T> items,
        TId? nextCursor = null,
        TId? previousCursor = null,
        int? totalCount = null)
    {
        return new CursorPaginatedResponse<T, TId>
        {
            Items = items,
            NextCursor = nextCursor,
            PreviousCursor = previousCursor,
            TotalCount = totalCount
        };
    }

    public static CursorPaginatedResponse<T, TId> Empty()
    {
        return new CursorPaginatedResponse<T, TId>
        {
            Items = [],
            NextCursor = null,
            PreviousCursor = null
        };
    }
}
