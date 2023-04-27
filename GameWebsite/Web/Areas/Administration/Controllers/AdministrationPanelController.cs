using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Web.Areas.Administration.Controllers
{
    [Route("/Administration/Home")]
    public class AdministrationPanelController : BaseAdministrationController
    { 
        public ActionResult Index()
        {
            return View();
        }

    }
}
