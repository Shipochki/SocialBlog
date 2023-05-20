using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SocialBlog.Core.Services.Favorite;
using SocialBlog.Core.Services.Favorite.Models;
using SocialBlog.Infranstructure;

namespace SocialBlog.Web.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            AllFavoriteViewModel model = await this.favoriteService.GetAllFavoriteByUserId(this.User.Id());

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            CreateFavoriteViewModel model = new CreateFavoriteViewModel() 
            {
                PostId = id,
                UserId = this.User.Id()
            };

            await this.favoriteService.CreateFavorite(model);

			return RedirectToAction("All", "Blog");
		}

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.favoriteService.Delete(id);

            return RedirectToAction("All", "Favorite");
        }
    }
}
