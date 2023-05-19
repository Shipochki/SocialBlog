namespace SocialBlog.Core.Services.User
{
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Data.Common;

	public class UserService : IUserService
	{
		private IRepository repo;

		public UserService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<string> GetNickNameById(string id)
		{
			User user = await this.repo.GetByIdAsync<User>(id);
			return user.NickName;
		}
	}
}
