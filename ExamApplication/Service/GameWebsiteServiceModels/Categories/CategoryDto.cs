using ExamApplication.Service.Models.Posts;

namespace ExamApplication.Service.Models.Categories
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}
