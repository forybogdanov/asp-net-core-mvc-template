namespace ExamApplication.Data.Models
{
    public class Post : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
    }
}