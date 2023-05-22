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
		public Task<IActionResult> Create()
		{
			return View(new CreateCommentViewModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> View(CreateCommentViewModel model)
		{
			model.UserId = this.User.Id();

			await this.commentService.CreateComment(model);

			return RedirectToAction("Details", "Blog", model.PostId);
		}
	}
}
