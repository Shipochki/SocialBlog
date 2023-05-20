using SocialBlog.Core.Services.Favorite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Favorite
{
    public interface IFavoriteService
    {
        Task CreateFavorite(CreateFavoriteViewModel model);

        Task<AllFavoriteViewModel> GetAllFavoriteByUserId(string userId);
    }
}
