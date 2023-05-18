namespace SocialBlog.Core.Services.Post.Models
{
	public class DetailsPostViewModel
	{
		public string Title { get; set; } = null!;

		public string Text { get; set; } = null!;

		public string Tag { get; set; } = null!;

		public string ImageUrlLink { get; set; } = null!;

		public int TimeForRead { get; set; }

		public string Created { get; set; } = null!;

		public int AuthorId { get; set; }

		public string AuthorFullName { get; set; } = null!;
	}
}
