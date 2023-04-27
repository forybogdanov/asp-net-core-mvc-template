using ExamApplication.Service.Models.Categories;
using ExamApplication.Service.Models.Posts;
using ExamApplication.Service.Models.Users;
using ExamApplication.Services.Categories;
using ExamApplication.Services.Posts;
using ExamApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamApplication.Web.Areas.Administration.Controllers
{
    [Route("Administration/Posts")]
    public class PostAdministrationController : BaseAdministrationController
    {
        private readonly IPostService service;
        private readonly ICategoryService categoryService;
        public PostAdministrationController(IPostService service, ICategoryService categoryService)
        {
            this.service = service;
            this.categoryService = categoryService;
        }
        public IActionResult Index(long id)
        {
            List<PostDto> posts = this.service.GetAllPosts();
            posts = posts.FindAll(post => post.Category.Id == id);
            PostViewData postViewData = new PostViewData(id, posts);
            return View(postViewData);
        }
        [HttpGet("Posts/Create/{categoryId}")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Posts/Create/{categoryId}")]
        public async Task<IActionResult> Create(long categoryId, PostDto postDto)
        {
            postDto.CreatedBy = new ExamApplicationUserDto
            {
                Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            postDto.Category = new CategoryDto
            {
                Id = categoryId,
                CreatedBy = new ExamApplicationUserDto{ }
            };
            await this.service.CreatePost(postDto);
            return Redirect("/Administration/Categories");
        }
        [Route("Posts/Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this.service.DeletePost(id);

            return Redirect("/Administration/Categories");
        
        }
        [Route("Posts/Edit/{id}")]
        [HttpGet("Posts/Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            return View(await this.service.GetPostById(id));
        }
        [Route("Posts/Edit/{id}")]
        [HttpPost("Posts/Edit/{id}")]
        public async Task<IActionResult> Edit(long id, PostDto postDto)
        {
            await this.service.UpdatePost(id, postDto);

            return Redirect("/Administration/Categories");
        }
        [Route("Posts/Details")]
        public async Task<IActionResult> Details(long id)
        {
            PostDto postDto = await this.service.GetPostById(id);
            PostDetailsViewData postDetailsViewData = new PostDetailsViewData(postDto);

            return View(postDetailsViewData);
        }
    }
}
