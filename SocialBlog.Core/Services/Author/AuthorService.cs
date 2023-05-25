namespace SocialBlog.Core.Services.Author
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Services.Author.Models;

	public class AuthorService : IAuthorService
	{
		private readonly IRepository repo;

		public AuthorService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task ApproveAuthor(int id)
		{
			Author author = await this.repo.GetByIdAsync<Author>(id);

			if(author == null)
			{
				throw new ArgumentException($"Does not exist author with this id: {id}");
			}

			author.IsActive = true;

			await this.repo.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			Author author = await this.repo.GetByIdAsync<Author>(id);

			if (author == null)
			{
				throw new ArgumentException($"Does not exist author with this id: {id}");
			}

			author.IsDeleted = true;

			await this.repo.SaveChangesAsync();
		}

		public async Task ActivevateAuthor(int id)
		{
			Author author = await this.repo.GetByIdAsync<Author>(id);

			if (author == null)
			{
				throw new ArgumentException($"Does not exist author with this id: {id}");
			}

			author.IsDeleted = false;

			await this.repo.SaveChangesAsync();
		}

		public async Task CreateAuthor(AuthorCreateServiceModel model)
		{
			Author author = new Author()
			{
				PhoneNumber = model.PhoneNumber,
				UserId = model.UserId,
			};

			await this.repo.AddAsync(author);
			await this.repo.SaveChangesAsync();
		}

		public async Task<List<AuthorCandidateViewModel>> GetAllCandidate()
		{
			List<AuthorCandidateViewModel> candidates = await this.repo.All<Author>()
				.Where(a => a.IsActive == false)
				.Select(a => new AuthorCandidateViewModel
				{
					Id = a.Id,
					PhoneNumber = a.PhoneNumber,
					NickName = a.User.NickName,
					ProfileImgLink = a.User.ProfileImgLink != null ? a.User.ProfileImgLink : "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
				})
				.ToListAsync();

			return candidates;
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
				return -1;
			}

			return author.Id;
        }

        public async Task<List<AdminAuthorViewModel>> GetAllAuthors()
        {
			List<AdminAuthorViewModel> authors = await this.repo
				 .All<Author>()
				 .Where(a => a.IsDeleted == false)
				 .Select(a => new AdminAuthorViewModel()
				 {
					 Id = a.Id,
					 PhoneNumber = a.PhoneNumber,
					 UserFirstName = a.User.FirstName,
					 UserLastName = a.User.LastName,
					 UserNickName = a.User.NickName,
					 IsActive = a.IsActive,
				 })
				 .ToListAsync();

			return authors;
        }

		public async Task Deactivate(int id)
		{
			Author author = await this.repo.GetByIdAsync<Author>(id);

			if (author == null)
			{
				throw new ArgumentException($"Does not exist author with this id: {id}");
			}

			author.IsActive = false;

			await this.repo.SaveChangesAsync();
		}
	}
}
