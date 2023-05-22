using Microsoft.AspNetCore.Mvc;
using SocialBlog.Core.Services.Post;
using SocialBlog.Core.Services.Post.Models;
using SocialBlog.Models;
using System.Diagnostics;

namespace SocialBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPostService postService;

        public HomeController(ILogger<HomeController> logger, IPostService postService)
        {
            this.logger = logger;
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeViewModel model = await this.postService.GetTopThreeFavoritePosts();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}