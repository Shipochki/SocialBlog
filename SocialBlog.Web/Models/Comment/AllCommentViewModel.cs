namespace SocialBlog.Web.Models.Comment
{
	using SocialBlog.Core.Services.Comment.Models;

	public class AllCommentViewModel
	{
		public IEnumerable<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
	}
}
