using SocialBlog.Core.Services.Author.Models;

namespace SocialBlog.Core.Services.Author
{
	public interface IAuthorService
	{
		Task<AuthorFullNameViewModel> GetAuthorFullNameById(int id);

		Task<int> GetAuthorIdByUserId(string userId);

		Task CreateAuthor(AuthorCreateViewModel model);

		Task<AllCandidateAuthorsViewModel> GetAllCandidate();

		Task ApproveAuthor(int id);

		Task DeleteAuthor(int id);

		Task ActivevateAuthor(int id);

		Task<AllAuthorViewModel> GetAllAuthors();
	}
}
