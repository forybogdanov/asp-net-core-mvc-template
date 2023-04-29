using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Posts;
using ExamApplication.Service.Mapping.Users;
using ExamApplication.Service.Models.Categories;

namespace ExamApplication.Service.Mapping.Categories
{
    public static class CategoryMappings
    {
        public static Category ToEntity(this CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                CreatedAt = categoryDto.CreatedAt,
                CreatedBy = categoryDto.CreatedBy.ToEntity(),
                /*Posts = categoryDto.Posts.Select(post => post.ToEntity()),*/
            };
        }

        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt,
                CreatedBy = category.CreatedBy.ToDto(),
                /*Posts = category.Posts.Select(post => post.ToDto()).ToList()*/
            };
        }
    }
}
