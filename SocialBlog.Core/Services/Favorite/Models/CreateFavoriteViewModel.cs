using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Favorite.Models
{
    public class CreateFavoriteViewModel
    {
        public string UserId { get; set; } = null!;

        public int PostId { get; set; }
    }
}
