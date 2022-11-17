namespace Application.ViewModels;
public class PageViewModel
{
    public const int DEFAULT_CURRENT_PAGE = 1;
    public const int DEFAULT_PAGE_SIZE = 10;

    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalPages { get; init; }

    public PageViewModel(int count, int pageNumber, int pageSize)
    {
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        PageNumber = pageNumber > TotalPages ? TotalPages : pageNumber;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;
}
