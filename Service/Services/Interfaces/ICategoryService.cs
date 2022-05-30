﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces;

public interface ICategoryService
{
    CategoryDto? GetCategoryByCategoryId(int categoryId);

    Task<IEnumerable<CategoryDto>> GetAllCategories();

}