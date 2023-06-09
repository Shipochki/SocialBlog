﻿namespace SocialBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SocialBlog.Core.Services.Favorite;
    using SocialBlog.Core.Services.Favorite.Models;
    using SocialBlog.Core.Services.Post;
    using SocialBlog.Infranstructure;
    using SocialBlog.Web.Models.Favorite;

    public class FavoriteController : Controller
    {
        private readonly IFavoriteService favoriteService;
        private readonly IPostService postService;

        public FavoriteController(IFavoriteService favoriteService, IPostService postService)
        {
            this.favoriteService = favoriteService;
            this.postService = postService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            AllFavoriteViewModel model = new AllFavoriteViewModel();
            model.Favorites = await this.favoriteService.GetAllFavoriteByUserId(this.User.Id());

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
