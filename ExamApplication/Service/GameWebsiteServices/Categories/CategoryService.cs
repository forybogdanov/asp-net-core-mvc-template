using ExamApplication.Data;
using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Categories;
using ExamApplication.Service.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ExamApplicationDbContext ExamApplicationDbContext;

        public CategoryService(ExamApplicationDbContext ExamApplicationDbContext)
        {
            this.ExamApplicationDbContext = ExamApplicationDbContext;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            Category category = categoryDto.ToEntity();
            category.CreatedBy = await this.ExamApplicationDbContext.Users.SingleOrDefaultAsync(user => user.Id == categoryDto.CreatedBy.Id);
            category.CreatedAt = DateTime.Now;
            await this.ExamApplicationDbContext.AddAsync(category);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            // TODO: set posts
            return category.ToDto();
        }

        public async Task<CategoryDto> DeleteCategory(long id)
        {
            Category category = this.ExamApplicationDbContext.Categories.SingleOrDefault(category => category.Id == id);
            if (category == null)
            {
                // TODO: throw exception
                return null;
            }

            CategoryDto categoryDto = category.ToDto();
            this.ExamApplicationDbContext.Remove(category);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return categoryDto;
        }

        public IQueryable<CategoryDto> GetAllCategories()
        {
            return this.ExamApplicationDbContext.Categories
                .Include(category => category.CreatedBy)
                .Select(category => category.ToDto());
        }

        public async Task<CategoryDto> GetCategoryById(long id)
        {
            Category category = this.ExamApplicationDbContext.Categories
                .Include(category => category.CreatedBy)
                .SingleOrDefault(category => category.Id == id);
            if (category == null)
            {
                // TODO: throw exception
                return null;
            }
            return category.ToDto();
        }

        public async Task<CategoryDto> UpdateCategory(long id, CategoryDto categoryDto)
        {
            Category category = this.ExamApplicationDbContext.Categories.SingleOrDefault(category => category.Id == id);
            if (category == null)
            {
                // TODO: throw exception
                return null;
            }
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            this.ExamApplicationDbContext.Update(category);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            // TODO: set posts
            return category.ToDto();    
        }
    }
}
