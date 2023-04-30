using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Users;
using ExamApplication.Service.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApplication.Service.Mapping.Events
{
    public static class EventMappings
    {
        public static Event ToEntity(this EventDto eventDto)
        {
            return new Event
            {
                Id = eventDto.Id,
                Date = eventDto.Date,
                Description = eventDto.Description,
                CreatedBy = eventDto.CreatedBy.ToEntity(),
                CreatedAt = eventDto.CreatedAt,
                Name = eventDto.Name,
            };
        }

        public static EventDto ToDto(this Event coolEvent)
        {
            return new EventDto
            {
                Id = coolEvent.Id,
                Date = coolEvent.Date,
                Description = coolEvent.Description,
                CreatedBy = coolEvent.CreatedBy.ToDto(),
                CreatedAt = coolEvent.CreatedAt,
                Name = coolEvent.Name
            };
        }
    }
}
