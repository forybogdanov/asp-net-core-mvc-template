using ExamApplication.Data;
using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Categories;
using ExamApplication.Service.Mapping.Posts;
using ExamApplication.Service.Mapping.Users;
using ExamApplication.Service.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly ExamApplicationDbContext ExamApplicationDbContext;

        public PostService(ExamApplicationDbContext ExamApplicationDbContext)
        {
            this.ExamApplicationDbContext = ExamApplicationDbContext;
        }
        public async Task<PostDto> CreatePost(PostDto postDto)
        {
            Post post = postDto.ToEntity();
            post.CreatedBy = await this.ExamApplicationDbContext.Users.SingleOrDefaultAsync(user => user.Id == postDto.CreatedBy.Id);
            post.Category = await this.ExamApplicationDbContext.Categories
                .Include(category => category.CreatedBy)
                .SingleOrDefaultAsync(category => category.Id == postDto.Category.Id);
            post.CreatedAt = DateTime.Now;
            await this.ExamApplicationDbContext.AddAsync(post);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return post.ToDto();
        }

        public async Task<PostDto> DeletePost(long id)
        {
            Post post = this.ExamApplicationDbContext.Posts
                .Include(post => post.Category)
                .Include(post => post.Category.CreatedBy)
                .Include(post => post.CreatedBy)
                .SingleOrDefault(post => post.Id == id);
            if (post == null)
            {
                // TODO: throw exception
                return null;
            }

            PostDto postDto = post.ToDto();
            this.ExamApplicationDbContext.Remove(post);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return postDto;
        }

        public List<PostDto> GetAllPosts()
        {
            /*IQueryable<PostDto> posts = this.ExamApplicationDbContext.Posts
                .Include(post => post.CreatedBy)
                .Include(post => post.Category)
                .Select((post) => 
                {
                    post.Comments = new List<Comment>();
                    return post;
                })
                .Select(post => post.toDto());*/
            List<Post> posts = this.ExamApplicationDbContext.Posts
                .Include(post => post.CreatedBy)
                .Include(post => post.Category).ToList();

            List<PostDto> postDtos = posts.Select((post) =>
            {
                return post.ToDto();
            }).ToList();
            return postDtos;
        }

        public async Task<PostDto> GetPostById(long id)
        {
            Post post = this.ExamApplicationDbContext.Posts
                .Include(post => post.CreatedBy)
                .Include(post => post.Category)
                .Include(post => post.Category.CreatedBy)
                .SingleOrDefault(post => post.Id == id);
            if (post == null)
            {
                // TODO: throw exception
                return null;
            }
            return post.ToDto();
        }

        public async Task<PostDto> UpdatePost(long id, PostDto postDto)
        {
            Post post = this.ExamApplicationDbContext.Posts
                .Include(post => post.Category)
                .Include(post => post.Category.CreatedBy)
                .SingleOrDefault(post => post.Id == id);
            if (post == null)
            {
                // TODO: throw exception
                return null;
            }
            post.Name = postDto.Name;
            post.Content = postDto.Content;
            this.ExamApplicationDbContext.Update(post);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            // TODO: set posts
            return post.ToDto();
        }
    }
}
