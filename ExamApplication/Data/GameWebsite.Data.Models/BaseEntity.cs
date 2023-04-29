namespace ExamApplication.Data.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public ExamApplicationUser CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
