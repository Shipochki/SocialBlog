namespace SocialBlog.Core.Services.Author
{
	using SocialBlog.Core.Services.Author.Models;

	public interface IAuthorService
	{
		Task<AuthorFullNameViewModel> GetAuthorFullNameById(int id);

		Task<int> GetAuthorIdByUserId(string userId);

		Task CreateAuthor(AuthorCreateServiceModel model);

		Task<List<AuthorCandidateViewModel>> GetAllCandidate();

		Task ApproveAuthor(int id);

		Task Delete(int id);

		Task ActivevateAuthor(int id);

		Task<List<AdminAuthorViewModel>> GetAllAuthors();

		Task Deactivate(int id);
	}
}
