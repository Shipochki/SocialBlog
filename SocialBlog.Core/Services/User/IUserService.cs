namespace SocialBlog.Core.Services.User
{
	using SocialBlog.Core.Services.User.Models;

	public interface IUserService
	{
		Task<string> GetNickNameById(string id);

		Task<string> GetUserProfileImgById(string id);

		Task<List<UserViewModel>> GetAllUsers();
	}
}
