using System.ComponentModel.DataAnnotations;
using static SocialBlog.Core.DataConstants.Post;

namespace SocialBlog.Core.Services.Post.Models
{
	public class EditPostViewModel
	{
		public int Id { get; set; }

		[Required]
		[MinLength(TitleMinLength)]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MinLength(DescriptionMinLength)]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MinLength(TextMinLength)]
		public string Text { get; set; } = null!;

		[Required]
		[MinLength(TagMinLength)]
		[MaxLength(TagMaxLength)]
		public string Tag { get; set; } = null!;

		[Required]
		public string ImageUrlLink { get; set; } = null!;

		[Required]
		public int TimeForRead { get; set; }

		[Required]
		public int AuthorId { get; set; }
	}
}
