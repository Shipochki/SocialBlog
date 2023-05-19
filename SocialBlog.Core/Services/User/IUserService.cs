using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.User
{
	public interface IUserService
	{
		Task<string> GetNickNameById(string id);
	}
}
