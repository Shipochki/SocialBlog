namespace SocialBlog.Core.Services.Comment.Models
{
	public class CommentViewModel
	{
		public int Id { get; set; }

		public string UserNickName { get; set; } = null!;

		public string Text { get; set; } = null!;

		public string Created { get; set; } = null!;

		public string ProfileImgLink { get; set; } = null!;

		public string UserId { get; set; } = null!;
	}
}
