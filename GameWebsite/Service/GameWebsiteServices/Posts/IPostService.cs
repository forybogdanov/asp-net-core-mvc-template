using ExamApplication.Service.Models.Posts;

namespace ExamApplication.Services.Posts
{
    public interface IPostService
    {
        Task<PostDto> CreatePost(PostDto postDto);
        Task<PostDto> DeletePost(long id);
        List<PostDto> GetAllPosts();
        Task<PostDto> GetPostById(long id);
        Task<PostDto> UpdatePost(long id, PostDto postDto);
    }
}
