namespace SocialBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SocialBlog.Core.Services.Post;
    using SocialBlog.Core.Services.Post.Models;

    public class BlogController : Controller
    {
        private readonly IPostService postService;

        public BlogController(IPostService _postService)
        {
            this.postService = _postService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            AllPostsViewModel models = await this.postService.All();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DetailsPostViewModel model = await this.postService.GetPostById(id);

            if(model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
