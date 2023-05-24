namespace SocialBlog.Core.Services.Comment
{
	using SocialBlog.Core.Services.Comment.Models;

	public interface ICommentService
	{
		Task CreateComment(CreateCommentViewModel model);

		Task<int> DeleteComment(int id);

		Task<List<CommentViewModel>> GetAllCommentByPostId(int postId);

		Task<List<int>> GetTopThreeCommentPostsIds();

		Task<List<CommentViewModel>> GetAllComment();
	}
}
