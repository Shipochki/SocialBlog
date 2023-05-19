namespace SocialBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SocialBlog.Core.Services.Author;
    using SocialBlog.Core.Services.Post;
    using SocialBlog.Core.Services.Post.Models;
    using static SocialBlog.Infranstructure.ClaimsPrincipalExtensions;

    public class BlogController : Controller
    {
        private readonly IPostService postService;
        private readonly IAuthorService authorService;

        public BlogController(IPostService _postService, IAuthorService authorService)
        {
            this.postService = _postService;
            this.authorService = authorService;
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

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new CreatePostViewModel());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			model.AuthorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());
            int postId = await this.postService.CreatePost(model);

            return View(nameof(Details), postId);
        }
    }
}
