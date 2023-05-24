namespace SocialBlog.Web.Models.User
{
	using SocialBlog.Core.Services.User.Models;

	public class AllUserViewModel
	{
		public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();
	}
}
