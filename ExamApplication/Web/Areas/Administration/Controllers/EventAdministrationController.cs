using ExamApplication.Service.Models.Events;
using ExamApplication.Service.Models.Users;
using ExamApplication.Services.Events;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamApplication.Web.Areas.Administration.Controllers
{
    [Route("Administration/Events")]
    public class EventAdministrationController : BaseAdministrationController
    {
        private readonly IEventService service;
        public EventAdministrationController(IEventService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(this.service.GetAllEvents());
        }
        [HttpGet("Events/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Events/Create")]
        public async Task<IActionResult> Create(EventDto eventDto)
        {
            eventDto.CreatedBy = new ExamApplicationUserDto
            {
                Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            await this.service.CreateEvent(eventDto);
            return Redirect("/Administration/Events");
        }
        [Route("Events/Edit/{id}")]
        [HttpGet("Events/Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            return View(await this.service.GetEventById(id));
        }
        [Route("Events/Edit/{id}")]
        [HttpPost("Events/Edit/{id}")]
        public async Task<IActionResult> Edit(long id, EventDto eventDto)
        {
            await this.service.UpdateEvent(id, eventDto);

            return Redirect("/Administration/Events");
        }
        [Route("Events/Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this.service.DeleteEvent(id);

            return Redirect("/Administration/Events");
        }
    }
}
