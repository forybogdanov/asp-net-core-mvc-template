using ExamApplication.Service.Models.Posts;

namespace ExamApplication.Web.Models
{
    public class PostViewData
    {
        public PostViewData(long categoryId, List<PostDto> posts)
        {
            CategoryId = categoryId;
            Posts = posts;
        }

        public long CategoryId { get; set; }
        public List<PostDto> Posts { get; set; } = new List<PostDto>();
    }
}
