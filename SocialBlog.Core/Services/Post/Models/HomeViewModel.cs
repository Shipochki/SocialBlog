using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Post.Models
{
	public class HomeViewModel
	{
		public IEnumerable<PostAllViewModel> TopFavoriteThree { get; set; }

		public IEnumerable<PostAllViewModel> TopCommentThree { get; set; }
	}
}
