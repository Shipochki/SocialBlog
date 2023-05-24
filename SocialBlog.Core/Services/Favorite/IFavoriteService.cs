namespace SocialBlog.Core.Services.Favorite
{
    using SocialBlog.Core.Services.Favorite.Models;

    public interface IFavoriteService
    {
        Task CreateFavorite(CreateFavoriteViewModel model);

        Task<List<FavoriteAllViewModel>> GetAllFavoriteByUserId(string userId);

        Task Delete(int id);

        Task<List<int>> GetTopThreeFavoritePostsIds();
	}
}
