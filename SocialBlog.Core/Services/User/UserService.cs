namespace SocialBlog.Core.Services.User
{
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Services.User.Models;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;

	public class UserService : IUserService
	{
		private readonly IRepository repo;

		public UserService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<List<UserViewModel>> GetAllUsers()
		{
            List<UserViewModel> users = await this.repo
				.All<User>()
				.Select(u => new UserViewModel()
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					NickName = u.NickName,
					IsDeleted = u.IsDeleted
				})
				.ToListAsync();

			return users;
		}

		public async Task<string> GetNickNameById(string id)
		{
			User user = await this.repo.GetByIdAsync<User>(id);
			return user.NickName;
		}

		public async Task<string> GetUserProfileImgById(string id)
		{
			User user = await this.repo.GetByIdAsync<User>(id);
			return user.ProfileImgLink != null ? user.ProfileImgLink : "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
		}
	}
}
