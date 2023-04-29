using ExamApplication.Services.Categories;
using ExamApplication.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        public HomeController(ICategoryService categoryService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }
        public IActionResult Index()
        {
            return View(this.categoryService.GetAllCategories().ToList());
        }
    }
}
