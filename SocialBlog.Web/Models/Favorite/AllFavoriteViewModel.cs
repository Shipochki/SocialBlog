namespace SocialBlog.Web.Models.Favorite
{
    using SocialBlog.Core.Services.Favorite.Models;

    public class AllFavoriteViewModel
    {
        public IEnumerable<FavoriteAllViewModel> Favorites { get; set; } = new List<FavoriteAllViewModel>();
    }
}
