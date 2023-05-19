namespace SocialBlog.Core.Services.Author.Models
{
	using System.ComponentModel.DataAnnotations;
	using static SocialBlog.Core.DataConstants.Author;

	public class AuthorCreateViewModel
	{
		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		[MinLength(PhoneNumberMinLength)]
		public string PhoneNumber { get; set; } = null!;

		public string UserId { get; set; } = null!;
	}
}
