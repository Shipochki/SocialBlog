using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Favorite.Models
{
    public class FavoriteAllViewModel
    {
        public int PostId { get; set; }

        public string PostImgUrlLink { get; set; } = null!;

        public string PostTitle { get; set; } = null!;
    }
}
