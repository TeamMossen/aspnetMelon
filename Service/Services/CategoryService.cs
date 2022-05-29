using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _appContext;

        public CategoryService(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public CategoryDto? GetCategoryByCategoryId(int categoryId)
            => _appContext.Categories.Where(c => c.CategoryId == categoryId).Select(c => (CategoryDto)c).FirstOrDefault();

        public IEnumerable<CategoryDto> GetAllCategories()
            => _appContext.Categories.Select(c => (CategoryDto)c);

    }
}
