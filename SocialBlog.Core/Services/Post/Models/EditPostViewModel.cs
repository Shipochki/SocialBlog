namespace SocialBlog.Core.Services.Post.Models
{
	public class EditPostViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string Text { get; set; } = null!;

		public string Tag { get; set; } = null!;

		public string ImageUrlLink { get; set; } = null!;

		public int TimeForRead { get; set; }

		public int AuthorId { get; set; }
	}
}
