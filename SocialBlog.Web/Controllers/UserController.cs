namespace SocialBlog.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using SocialBlog.Core.Services.User;
	using SocialBlog.Infranstructure;
	using SocialBlog.Web.Models.User;

	public class UserController : Controller
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> All()
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			AllUserViewModel model = new AllUserViewModel();
			model.Users = await this.userService.GetAllUsers();
			return View(model);
		}
	}
}
