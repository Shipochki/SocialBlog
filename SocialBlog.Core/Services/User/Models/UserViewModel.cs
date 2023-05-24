using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.User.Models
{
	public class UserViewModel
	{
		public string Id { get; set; } = null!;

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string NickName { get; set; } = null!;

		public bool IsDeleted { get; set; } 
	}
}
