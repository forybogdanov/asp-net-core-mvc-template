using ExamApplication.Service.Models.Events;

namespace ExamApplication.Web.Models
{
    public class HomeViewData
    {
        public List<EventDto> Events { get; set; }
        public string Search { get; set; }

        public HomeViewData(List<EventDto> events, string search)
        {
            Events = events;
            Search = search;
        }

        public HomeViewData()
        {
            Events = new List<EventDto>();
            Search = "";
        }
    }
}
