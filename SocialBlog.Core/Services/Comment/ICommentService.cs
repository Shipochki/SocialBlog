using SocialBlog.Core.Services.Comment.Models;

namespace SocialBlog.Core.Services.Comment
{
	public interface ICommentService
	{
		Task CreateComment(CreateCommentViewModel model);

		Task<int> DeleteComment(int id);

		Task<List<CommentViewModel>> GetAllCommentByPostId(int postId);

		Task<List<int>> GetTopThreeCommentPostsIds();

		Task<List<CommentViewModel>> GetAllComment();
	}
}
