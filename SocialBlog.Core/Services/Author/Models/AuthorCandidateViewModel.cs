using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Author.Models
{
	public class AuthorCandidateViewModel
	{
		public int Id { get; set; }

		public string PhoneNumber { get; set; } = null!;

		public string NickName { get; set; } = null!;

		public string? ProfileImgLink { get; set; }
	}
}
