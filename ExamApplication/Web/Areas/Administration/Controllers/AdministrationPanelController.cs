using ExamApplication.Services.Users;
using ExamApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Web.Areas.Administration.Controllers
{
    [Route("/Administration/Home")]
    public class AdministrationPanelController : BaseAdministrationController
    {
        private readonly IUserService service;
        public AdministrationPanelController(IUserService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            AdministrationPanelViewData data = new AdministrationPanelViewData(this.service.GetUsersCount(), 0, 0);
            return View(data);
        }

    }
}
