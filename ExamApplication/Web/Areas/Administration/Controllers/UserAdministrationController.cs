using ExamApplication.Data.Models;
using ExamApplication.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Web.Areas.Administration.Controllers
{
    [Route("Administration/Users")]
    public class UserAdministrationController : BaseAdministrationController
    {
        private readonly IUserService service;


        /*private readonly UserManager<ExamApplicationUser> userManager;*/
        /*public UserAdministrationController(IUserService service, 
            UserManager<ExamApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }*/
        public UserAdministrationController(IUserService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            return View(this.service.GetAllUsers());
        }

        /*[HttpGet("/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Create")]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            categoryDto.CreatedBy = new ExamApplicationUserDto
            {
                Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            await this.service.CreateCategory(categoryDto);
            return Redirect("/Administration/Categories");
        }
        [Route("Edit/{id}")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            *//*return View((await this.service.getCategoryById(id)).ToWebModel());*//*
            return View((await this.service.GetCategoryById(id)));
        }
    [Route("Edit/{id}")]
    [HttpPost("Edit/{id}")]
    public async Task<IActionResult> Edit(long id, CategoryDto categoryDto)
    {
        await this.service.UpdateCategory(id, categoryDto);

        return Redirect("/Administration/Categories");
    }
    [Route("/Delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await this.service.DeleteCategory(id);

        return Redirect("/Administration/Categories");
    }*/
    [Route("Users/Delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await this.service.DeleteUser(id);

        return Redirect("/Administration/Users");
    }
    }
}
