using System.Reflection;
using Infrastructure.Models.Parameters.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Models.Parameters;

public class PageParameters : IPageParameters, IExtensionBinder<PageParameters>
{
    private const int MaxPageSize = 20;
    private int _pageNumber;
    private int _pageSize = 10;

    public PageParameters(int page, int pageSize)
    {
        PageNumber = page;
        PageSize = pageSize;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) || (value == 0) ? MaxPageSize : value;
    }

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = (value == 0) ? 1 : value;
    }

    public static ValueTask<PageParameters?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        int.TryParse(httpContext.Request.Query["page"], out var page);
        int.TryParse(httpContext.Request.Query["page-size"], out var pageSize);

        return ValueTask.FromResult<PageParameters?>(
            new PageParameters(page, pageSize)
        );
    }

}