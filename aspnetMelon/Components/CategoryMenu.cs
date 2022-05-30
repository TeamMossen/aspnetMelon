using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace aspnetMelon.Components;

public class CategoryMenu : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryMenu(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _categoryService.GetAllCategories().OrderBy(c => c.CategoryName);

        return View(categories);
    }
}