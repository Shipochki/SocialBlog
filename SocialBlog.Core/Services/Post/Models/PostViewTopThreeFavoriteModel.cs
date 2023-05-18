using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Post.Models
{
	public class PostViewTopThreeFavoriteModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string ImageUrlLink { get; set; } = null!;

		public string Created { get; set; } = null!;

		public string AuthorFullName { get; set; } = null!;

		public int FavoriteCounter { get; set; }
	}
}
