namespace SocialBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SocialBlog.Core.Services.Author;
    using SocialBlog.Core.Services.Post;
    using SocialBlog.Core.Services.Post.Models;
    using SocialBlog.Web.Models.Post;
    using System.Linq;
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
        public async Task<IActionResult> All(AllPostsQueryModel query)
        {
            PostQueryServiceModel queryResult = await this.postService
                .All(
                query.SearchTerm, 
                query.CurrentPage, 
                AllPostsQueryModel.PostsPerPage);

            query.TotalPostsCount = queryResult.TotalPostsCount;
            query.Posts = queryResult.Posts;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DetailsPostViewModel model = await this.postService.GetDetailsPostById(id);

            if(model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            if (await this.authorService.GetAuthorIdByUserId(this.User.Id()) == -1)
            {
                if (!this.User.IsAdmin())
                {
                    return Unauthorized();
                }
            }

            return View(new CreatePostViewModel());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (await this.authorService.GetAuthorIdByUserId(this.User.Id()) == -1)
            {
                if (!this.User.IsAdmin())
                {
                    return Unauthorized();
                }
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(All));
            }

            model.AuthorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());
            int id = await this.postService.CreatePost(model);

            TempData["message"] = $"You have sucssessfuly added a post '{model.Title}'!";

            return RedirectToAction("Details", "Blog", new { id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            EditPostViewModel post = await this.postService.GetEditPostById(id);

            if(post == null)
            {
                return BadRequest();
            }

            if (await this.authorService.GetAuthorIdByUserId(this.User.Id()) == -1)
            {
                if (!this.User.IsAdmin())
                {
                    return Unauthorized();
                }
            }

            return View(post);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            if (await this.authorService.GetAuthorIdByUserId(this.User.Id()) == -1)
            {
                if (!this.User.IsAdmin())
                {
                    return Unauthorized();
                }
            }

			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(All));
			}

			await this.postService.EditPost(model);

            TempData["message"] = $"You have sucssessfuly edit a post '{model.Title}'!";

            return RedirectToAction(nameof(Details), new { model.Id });
		}

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            PostDeleteViewModel model = await this.postService.GetPostDeleteViweById(id);

            if(model == null)
            {
                return BadRequest();
            }

			int authorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());

			if (model.AuthorId != authorId)
			{
				if (!this.User.IsAdmin())
				{
					return Unauthorized();
				}
			}

			return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(PostDeleteViewModel model)
        {
			int authorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());

			if (model.AuthorId != authorId && !this.User.IsAdmin())
			{
				if (!this.User.IsAdmin())
				{
					return Unauthorized();
				}
			}

            await this.postService.DeletePost(model.Id);

            TempData["message"] = $"You have sucssessfuly delete a post '{model.Title}'!";

            return View(nameof(All));
		}

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllByAuthor()
        {
            int authorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());

            if(authorId == -1)
            {
                return View(nameof(All));
            }

            AllPostsViewModel model = new AllPostsViewModel();
            model.Posts = await this.postService.GetAllPostsByAuthorId(authorId);
            model.PostsCount = model.Posts.Count();

            return View(model);
        }

        [HttpGet]
        [Authorize]
		public async Task<IActionResult> AdminAll()
		{
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

			AllPostsViewModel model = new AllPostsViewModel();
			model.Posts = await this.postService.GetAllPosts();
			model.PostsCount = model.Posts.Count();

			return View(model);
		}
	}
}
