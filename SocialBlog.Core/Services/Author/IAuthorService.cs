using SocialBlog.Core.Services.Author.Models;

namespace SocialBlog.Core.Services.Author
{
	public interface IAuthorService
	{
		Task<AuthorFullNameViewModel> GetAuthorFullNameById(int id);

		Task<int> GetAuthorIdByUserId(string userId);

    }
}
