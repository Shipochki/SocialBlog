namespace SocialBlog.Core.Services.Favorite
{
    using SocialBlog.Core.Data.Entities;
    using SocialBlog.Core.Data.Common;
    using SocialBlog.Core.Services.Favorite.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;

    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository repo;

        public FavoriteService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateFavorite(CreateFavoriteViewModel model)
        {
            if(await this.repo.All<Favorite>()
                .FirstOrDefaultAsync(
                f => f.UserId == model.UserId && 
                f.PostId == model.PostId) != null)
            {
                return;
            }

            Favorite favorite = new Favorite()
            {
                UserId = model.UserId,
                PostId = model.PostId,
            };

            await this.repo.AddAsync(favorite);

            await this.repo.SaveChangesAsync();
        }

        public async Task<AllFavoriteViewModel> GetAllFavoriteByUserId(string userId)
        {
            AllFavoriteViewModel model = new AllFavoriteViewModel()
            {
                Favorites = await this.repo.All<Favorite>()
                .Where(f => f.UserId == userId)
                .Select(f => new FavoriteAllViewModel()
                {
                    PostId = f.PostId,
                    PostTitle = f.Post.Title,
                    PostImgUrlLink = f.Post.ImageUrlLink
                })
                .ToListAsync()
            };

            return model;
        }
    }
}
