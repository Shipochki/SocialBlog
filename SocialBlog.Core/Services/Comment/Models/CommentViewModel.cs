using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Comment.Models
{
	public class CommentViewModel
	{
		public int Id { get; set; }

		public string UserNickName { get; set; } = null!;

		public string Text { get; set; } = null!;

		public string Created { get; set; } = null!;

		public string ProfileImgLink { get; set; } = null!;
	}
}
