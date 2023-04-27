using GameWebsite.Service.Models.Categories;

namespace GameWebsite.Service.Models.Posts
{
    public class PostDto : BaseDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
    }
}
