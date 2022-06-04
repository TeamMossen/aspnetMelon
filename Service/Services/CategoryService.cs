using Infrastructure.Models;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _appContext;

    public CategoryService(AppDbContext appContext)
    {
        _appContext = appContext;
    }
    public async Task<CategoryDto?> GetCategoryByCategoryId(int categoryId)
        => await _appContext.Categories.Where(c => c.CategoryId == categoryId).Select(c => (CategoryDto)c!).FirstOrDefaultAsync();

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        => await _appContext.Categories.Select(c => (CategoryDto)c!).ToListAsync();

}