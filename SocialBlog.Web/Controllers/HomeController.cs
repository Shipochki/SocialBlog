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

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}