namespace SocialBlog.Web.Models.Post
{
	using SocialBlog.Core.Services.Post.Models;

	public class HomeViewModel
	{
		public IEnumerable<PostAllViewModel> TopFavoriteThree { get; set; } = new List<PostAllViewModel>();

		public IEnumerable<PostAllViewModel> TopCommentThree { get; set; } = new List<PostAllViewModel>();
	}
}
