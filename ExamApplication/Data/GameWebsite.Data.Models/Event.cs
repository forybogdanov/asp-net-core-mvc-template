
namespace ExamApplication.Data.Models
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        // TO DO: add photo
    }
}
