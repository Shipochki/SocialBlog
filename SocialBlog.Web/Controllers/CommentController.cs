namespace SocialBlog.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using SocialBlog.Core.Services.Comment;
	using SocialBlog.Core.Services.Comment.Models;
	using SocialBlog.Infranstructure;
	using SocialBlog.Web.Models.Comment;

	public class CommentController : Controller
	{
		private readonly ICommentService commentService;

		public CommentController(ICommentService commentService)
		{
			this.commentService = commentService;
		}

		[HttpGet]
		[Authorize]
		public IActionResult Create(int id)
		{
			return View(new CreateCommentViewModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(CreateCommentViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			model.UserId = this.User.Id();

			int id = int.Parse(HttpContext.Request.Path.Value.ToString().Split('/').Last());
			model.PostId = id;

			await this.commentService.CreateComment(model);

			return RedirectToAction("Details", "Blog", new { id });
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			id = await this.commentService.DeleteComment(id);

			return RedirectToAction("Details", "Blog", new { id });
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			AllCommentViewModel comments = new AllCommentViewModel();
			comments.Comments = await this.commentService.GetAllComment();

			return View(comments);
		}
	}
}
