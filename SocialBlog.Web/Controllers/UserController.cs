using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialBlog.Core.Services.User;
using SocialBlog.Core.Services.User.Models;
using SocialBlog.Infranstructure;

namespace SocialBlog.Web.Controllers
{
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

			AllUserViewModel model = await this.userService.GetAllUsers();
			return View(model);
		}
	}
}
