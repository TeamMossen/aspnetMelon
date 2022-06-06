namespace Infrastructure.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto?> GetCategoryByCategoryId(int categoryId);

    Task<IEnumerable<CategoryDto>> GetAllCategories();

}