namespace SocialBlog.Core.Services.Author.Models
{
	public class AuthorCandidateViewModel
	{
		public int Id { get; set; }

		public string PhoneNumber { get; set; } = null!;

		public string NickName { get; set; } = null!;

		public string? ProfileImgLink { get; set; }
	}
}
