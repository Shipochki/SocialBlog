﻿namespace SocialBlog.Core.Services.Author
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

		public async Task CreateAuthor(AuthorCreateViewModel model)
		{
			Author author = new Author()
			{
				PhoneNumber = model.PhoneNumber,
				UserId = model.UserId,
			};

			await this.repo.AddAsync(author);
			await this.repo.SaveChangesAsync();
		}

		public async Task<AllCandidateAuthorsViewModel> GetAllCandidate()
		{
			AllCandidateAuthorsViewModel model = new AllCandidateAuthorsViewModel();

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

			model.Candidates = candidates;

			return model;
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
    }
}
