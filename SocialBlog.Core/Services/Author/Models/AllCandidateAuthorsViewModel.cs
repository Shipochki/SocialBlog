using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Author.Models
{
	public class AllCandidateAuthorsViewModel
	{
		public IEnumerable<AuthorCandidateViewModel> Candidates { get; set; }
	}
}
