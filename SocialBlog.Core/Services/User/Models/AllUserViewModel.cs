using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.User.Models
{
	public class AllUserViewModel
	{
		public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();
	}
}
