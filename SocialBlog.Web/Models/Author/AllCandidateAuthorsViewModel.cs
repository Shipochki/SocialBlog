namespace SocialBlog.Web.Models.Author
{
	using SocialBlog.Core.Services.Author.Models;

	public class AllCandidateAuthorsViewModel
	{
		public IEnumerable<AuthorCandidateViewModel> Candidates { get; set; } = new List<AuthorCandidateViewModel>();
	}
}
