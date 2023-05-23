using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialBlog.Core.Services.Author;
using SocialBlog.Core.Services.Author.Models;
using SocialBlog.Core.Services.User;
using SocialBlog.Infranstructure;

namespace SocialBlog.Web.Controllers
{
	public class AuthorController : Controller
	{
		private IAuthorService authorService;

		public AuthorController(IAuthorService authorService)
		{
			this.authorService = authorService;
		}

		[HttpGet]
		[Authorize]
		public IActionResult Create()
		{
			AuthorCreateViewModel model = new AuthorCreateViewModel();
			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(AuthorCreateViewModel model)
		{
			model.UserId = this.User.Id();
			await this.authorService.CreateAuthor(model);

			return View(nameof(AllCandidate));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AllCandidate()
		{
			AllCandidateAuthorsViewModel model = await this.authorService.GetAllCandidate();
			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Approve(int id)
		{
			await this.authorService.ApproveAuthor(id);

			return View(nameof(AllCandidate));
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
		{
			await this.authorService.DeleteAuthor(id);

			return View(nameof(AllCandidate));
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Activate(int id)
		{
			await this.authorService.ActivevateAuthor(id);

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> All()
		{
			AllAuthorViewModel model = await this.authorService.GetAllAuthors();

			return View(model);
		}
	}
}
