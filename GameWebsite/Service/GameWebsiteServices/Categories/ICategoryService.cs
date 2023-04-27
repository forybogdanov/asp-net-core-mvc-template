﻿using ExamApplication.Service.Models.Categories;

namespace ExamApplication.Services.Categories
{

    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
        Task<CategoryDto> DeleteCategory(long id);
        IQueryable<CategoryDto> GetAllCategories();
        Task<CategoryDto> GetCategoryById(long id);
        Task<CategoryDto> UpdateCategory(long id, CategoryDto categoryDto);

    }
}
