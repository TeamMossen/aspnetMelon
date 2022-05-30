﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _appContext;

    public CategoryService(AppDbContext appContext)
    {
        _appContext = appContext;
    }
    public CategoryDto? GetCategoryByCategoryId(int categoryId)
        => _appContext.Categories.Where(c => c.CategoryId == categoryId).Select(c => (CategoryDto)c!).FirstOrDefault();

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        => await _appContext.Categories.Select(c => (CategoryDto)c!).ToListAsync();

}