namespace SocialBlog.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SocialBlog.Core.Services.Post;
    using SocialBlog.Models;
    using SocialBlog.Web.Models.Post;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.TopFavoriteThree = await this.postService.GetTopThreeFavoritePosts();
            model.TopCommentThree = await this.postService.GetTopThreeCommentPosts();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}