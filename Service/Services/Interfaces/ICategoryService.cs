namespace Service.Services.Interfaces;

public interface ICategoryService
{
    CategoryDto? GetCategoryByCategoryId(int categoryId);

    Task<IEnumerable<CategoryDto>> GetAllCategories();

}