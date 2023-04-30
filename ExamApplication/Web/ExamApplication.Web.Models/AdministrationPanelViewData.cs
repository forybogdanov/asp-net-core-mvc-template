
namespace ExamApplication.Web.Models
{
    public class AdministrationPanelViewData
    {
        public int UsersCount { get; set; }
        public int EventsCount { get; set; }
        public int ReservedCount { get; set; }

        public AdministrationPanelViewData(int userCount, int eventsCount, int reserved)
        {
            UsersCount = userCount;
            EventsCount = eventsCount;
            ReservedCount = reserved;
        }
    }
}
