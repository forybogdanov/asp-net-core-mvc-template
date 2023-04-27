using GameWebsite.Service.Models.Posts;

namespace GameWebSite.Web.Models
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
