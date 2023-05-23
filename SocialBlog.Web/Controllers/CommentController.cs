using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialBlog.Core.Services.Comment;
using SocialBlog.Core.Services.Comment.Models;
using SocialBlog.Infranstructure;

namespace SocialBlog.Web.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService commentService;

		public CommentController(ICommentService commentService)
		{
			this.commentService = commentService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create(int id)
		{
			return View(new CreateCommentViewModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(CreateCommentViewModel model)
		{
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
			AllCommentViewModel comments = new AllCommentViewModel();
			comments.Comments = await this.commentService.GetAllComment();

			return View(comments);
		}
	}
}
