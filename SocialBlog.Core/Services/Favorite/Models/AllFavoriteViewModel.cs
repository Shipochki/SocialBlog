using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Favorite.Models
{
    public class AllFavoriteViewModel
    {
        public IEnumerable<FavoriteAllViewModel> Favorites { get; set; }
    }
}
