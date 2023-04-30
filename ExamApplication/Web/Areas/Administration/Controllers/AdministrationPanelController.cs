using ExamApplication.Services.Events;
using ExamApplication.Services.Users;
using ExamApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Web.Areas.Administration.Controllers
{
    [Route("/Administration/Home")]
    public class AdministrationPanelController : BaseAdministrationController
    {
        private readonly IUserService userService;
        private readonly IEventService eventService;
        public AdministrationPanelController(IUserService userService, IEventService eventService)
        {
            this.userService = userService;
            this.eventService = eventService;
        }
        public ActionResult Index()
        {
            AdministrationPanelViewData data = new AdministrationPanelViewData(this.userService.GetUsersCount(), this.eventService.GetEventsCount(), 0);
            return View(data);
        }

    }
}
