

namespace ExamApplication.Service.Models.Events
{
    public class EventDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        // TO DO: add photo
    }
}
