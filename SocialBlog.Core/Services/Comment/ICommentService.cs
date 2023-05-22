using SocialBlog.Core.Services.Comment.Models;

namespace SocialBlog.Core.Services.Comment
{
	public interface ICommentService
	{
		Task CreateComment(CreateCommentViewModel model);
	}
}
