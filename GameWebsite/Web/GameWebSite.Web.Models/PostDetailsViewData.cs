using ExamApplication.Service.Models.Posts;

namespace ExamApplication.Web.Models
{
    public class PostDetailsViewData
    {
        public PostDetailsViewData(PostDto post)
        {
            Post = post;
        }

        public PostDto Post { get; set; }
    }
}
