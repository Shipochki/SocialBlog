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
            AllPostsViewModel models = await postService.All();

            return View(models);
        }
    }
}
