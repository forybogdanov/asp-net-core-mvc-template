using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Categories;
using ExamApplication.Service.Mapping.Users;
using ExamApplication.Service.Models.Posts;

namespace ExamApplication.Service.Mapping.Posts
{
    public static class PostMappings
    {
        public static Post ToEntity(this PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                Name = postDto.Name,
                Content = postDto.Content,
                CreatedAt = postDto.CreatedAt,
                Category = postDto.Category.ToEntity(),
                CreatedBy = postDto.CreatedBy.ToEntity(),
            }; 
        }

        public static PostDto ToDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Category = post.Category.ToDto(),
                CreatedBy = post.CreatedBy.ToDto(),
            };
        }
    }
}
