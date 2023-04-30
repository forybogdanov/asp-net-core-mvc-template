using ExamApplication.Service.Models.Events;
using ExamApplication.Services.Categories;
using ExamApplication.Services.Events;
using ExamApplication.Services.Posts;
using ExamApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Web.Controllers
{
    public class HomeController : Controller
    { 
    
        private readonly IEventService eventService;
        public HomeController(IEventService eventService)
        { 
            this.eventService = eventService;
        }
        public IActionResult Index()
        {
            HomeViewData viewData = new HomeViewData(this.eventService.GetAllEvents(), "");
            return View(viewData);
        }
        public IActionResult Search(HomeViewData viewData)
        {
            List<EventDto> events;
            if (viewData.Search == null)
            {
                events = this.eventService.GetAllEvents();
            }
            else
            {
                events = this.eventService.GetAllEvents().Where(e => e.Name.StartsWith(viewData.Search)).ToList();
            }
            viewData.Events = events;
            return View(viewData);
        }
    }
}
