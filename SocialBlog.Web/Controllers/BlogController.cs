namespace SocialBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using SocialBlog.Core.Data.Entities;
    using SocialBlog.Core.Services.Author;
    using SocialBlog.Core.Services.Post;
    using SocialBlog.Core.Services.Post.Models;
    using static SocialBlog.Core.DataConstants;
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

            model.AuthorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());
            int postId = await this.postService.CreatePost(model);

            return View(nameof(Details), postId);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            EditPostViewModel post = await this.postService.GetEditPostById(id);

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

            await this.postService.EditPost(model);

            return RedirectToAction(nameof(Details), new { model.Id });
		}

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            PostDeleteViewModel model = await this.postService.GetPostDeleteViweById(id);
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

			if (model.AuthorId != authorId)
			{
				if (!this.User.IsAdmin())
				{
					return Unauthorized();
				}
			}

            await this.postService.DeletePost(model.Id);

            return View(nameof(All));
		}

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllByAuthor()
        {
            int authorId = await this.authorService.GetAuthorIdByUserId(this.User.Id());

            AllPostsViewModel model = await this.postService.GetAllPostsByAuthorId(authorId);

            return View(model);
        }
    }
}
