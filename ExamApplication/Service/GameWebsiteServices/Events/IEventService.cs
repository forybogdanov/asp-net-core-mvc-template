using ExamApplication.Service.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApplication.Services.Events
{
    public interface IEventService
    {
        Task<EventDto> CreateEvent(EventDto eventDto);
        Task<EventDto> DeleteEvent(long id);
        List<EventDto> GetAllEvents();
        Task<EventDto> GetEventById(long id);
        Task<EventDto> UpdateEvent(long id, EventDto eventDto);
        int GetEventsCount();
    }
}
