using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Comment.Models
{
	public class AllCommentViewModel
	{
		public IEnumerable<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
	}
}
