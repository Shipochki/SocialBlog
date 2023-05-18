namespace SocialBlog.Core.Services.Author
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Services.Author.Models;

	public class AuthorService : IAuthorService
	{
		private IRepository repo;

		public AuthorService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<AuthorFullNameViewModel> GetAuthorFullNameById(int id)
		{
			AuthorFullNameViewModel? author = await this.repo.All<Author>()
				.Where(a => a.Id == id)
				.Select(a => new AuthorFullNameViewModel
				{
					FirstName = a.User.FirstName,
					LastName = a.User.LastName,
				})
				.FirstOrDefaultAsync();

			if(author == null)
			{
				throw new ArgumentException("Author Id is not correct!");
			}

			return author;
		}

        public async Task<int> GetAuthorIdByUserId(string userId)
        {
            Author author = await this.repo
				.All<Author>()
				.FirstOrDefaultAsync(a => a.UserId == userId);

			if(author == null) 
			{
				throw new ArgumentException("Invalid userId or Invalid Author");
			}

			return author.Id;
        }
    }
}
