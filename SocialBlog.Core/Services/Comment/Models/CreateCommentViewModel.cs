namespace SocialBlog.Core.Services.Comment.Models
{
	using System.ComponentModel.DataAnnotations;
	using static SocialBlog.Core.DataConstants.Comment;

	public class CreateCommentViewModel
	{
		[Required]
		public int PostId { get; set; }

		[Required]
		public string UserId { get; set; } = null!;

		[Required]
		[MaxLength(TextMaxLength)]
		[MinLength(TextMinLength)]
		public string Text { get; set; } = null!;
	}
}
