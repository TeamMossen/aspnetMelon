namespace Infrastructure.Parameters;

public class PageParameters : IPageParameters
{
    private const int MaxPageSize = 20;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;

    public PageParameters(int page, int pageSize)
    {
        PageNumber = page;
        PageSize = pageSize;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}