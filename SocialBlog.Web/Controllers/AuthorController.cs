namespace SocialBlog.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using SocialBlog.Core.Services.Author;
	using SocialBlog.Core.Services.Author.Models;
	using SocialBlog.Web.Models.Author;
	using SocialBlog.Infranstructure;


	public class AuthorController : Controller
	{
		private IAuthorService authorService;

		public AuthorController(IAuthorService authorService)
		{
			this.authorService = authorService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create()
		{
			if(await this.authorService.GetAuthorIdByUserId(this.User.Id()) != -1)
			{
                TempData["message"] = "Your application has been sent.";
                return RedirectToAction("All", "Blog");
			}

			AuthorCreateServiceModel model = new AuthorCreateServiceModel();
			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(AuthorCreateServiceModel model)
		{
            if (await this.authorService.GetAuthorIdByUserId(this.User.Id()) != -1)
            {
                TempData["message"] = "Your application has been sent.";
                return RedirectToAction("All", "Blog");
            }

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

            model.UserId = this.User.Id();
			await this.authorService.CreateAuthor(model);

			return View(nameof(AllCandidate));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AllCandidate()
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			AllCandidateAuthorsViewModel model = new AllCandidateAuthorsViewModel();
			model.Candidates = await this.authorService.GetAllCandidate();
			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Approve(int id)
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			await this.authorService.ApproveAuthor(id);

			return View(nameof(AllCandidate));
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			await this.authorService.Delete(id);

			return View(nameof(AllCandidate));
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Activate(int id)
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			await this.authorService.ActivevateAuthor(id);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> All()
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			AllAuthorViewModel model = new AllAuthorViewModel();
			model.Authors = await this.authorService.GetAllAuthors();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Deactivate(int id)
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			await this.authorService.Deactivate(id);

			return View(nameof(All));
		}
	}
}
