using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.ViewComponents;

public class CategoryMenu : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryMenu(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryService.GetAllCategories();
        
        return View(categories.OrderBy(c => c.CategoryName));
    }
}