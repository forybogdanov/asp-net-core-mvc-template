using ExamApplication.Service.Models.Users;

namespace ExamApplication.Service.Models
{
    public class BaseDto
    {
        public long Id { get; set; }
        public ExamApplicationUserDto CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
