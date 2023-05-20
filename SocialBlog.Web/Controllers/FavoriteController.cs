using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> All()
        {
            AllFavoriteViewModel model = await this.favoriteService.GetAllFavoriteByUserId(this.User.Id());

            return View(model);
        }

        [Authorize]
        public async Task Create(int postId)
        {
            CreateFavoriteViewModel model = new CreateFavoriteViewModel() 
            {
                PostId = postId,
                UserId = this.User.Id()
            };
            await this.favoriteService.CreateFavorite(model);
        }
    }
}
