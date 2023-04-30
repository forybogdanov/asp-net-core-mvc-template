using ExamApplication.Data;
using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Events;
using ExamApplication.Service.Mapping.Users;
using ExamApplication.Service.Models.Events;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExamApplication.Services.Events
{
    public class EventService : IEventService
    {
        private readonly ExamApplicationDbContext ExamApplicationDbContext;
        public EventService(ExamApplicationDbContext ExamApplicationDbContext)
        {
            this.ExamApplicationDbContext = ExamApplicationDbContext;
        }
        public async Task<EventDto> CreateEvent(EventDto eventDto)
        {
            Event coolEvent = eventDto.ToEntity();
            coolEvent.CreatedBy = await this.ExamApplicationDbContext.Users.SingleOrDefaultAsync(user => user.Id == eventDto.CreatedBy.Id);
            coolEvent.CreatedAt = DateTime.Now;
            await this.ExamApplicationDbContext.AddAsync(coolEvent);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return coolEvent.ToDto();
        }

        public async Task<EventDto> DeleteEvent(long id)
        {
            Event coolEvent = this.ExamApplicationDbContext.Events
                .Include(e => e.CreatedBy)
                .SingleOrDefault(coolEvent => coolEvent.Id == id);
            if (coolEvent == null)
            {
                // TODO: throw exception
                return null;
            }

            EventDto eventDto = coolEvent.ToDto();
            this.ExamApplicationDbContext.Remove(coolEvent);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return eventDto;
        }

        public List<EventDto> GetAllEvents()
        {
            return this.ExamApplicationDbContext.Events
                .Include(e => e.CreatedBy)
                .Select(e => e.ToDto())
                .ToList();
        }

        public async Task<EventDto> GetEventById(long id)
        {
            return this.ExamApplicationDbContext.Events
                .Include(e => e.CreatedBy)
                .SingleOrDefault(e => e.Id == id)
                .ToDto();
        }

        public int GetEventsCount()
        {
            return this.ExamApplicationDbContext.Events.Count();
        }

        public async Task<EventDto> UpdateEvent(long id, EventDto eventDto)
        {
            Event coolEvent = this.ExamApplicationDbContext.Events
                .Include(e => e.CreatedBy)
                .SingleOrDefault(e => e.Id == id);
            if (coolEvent == null)
            {
                // TODO: throw exception
                return null;
            }
            eventDto.CreatedBy = coolEvent.CreatedBy.ToDto();
            coolEvent.Name = eventDto.Name;
            coolEvent.Description = eventDto.Description;
            coolEvent.Date = eventDto.Date;
            this.ExamApplicationDbContext.Update(coolEvent);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return coolEvent.ToDto();
        }
    }
}
