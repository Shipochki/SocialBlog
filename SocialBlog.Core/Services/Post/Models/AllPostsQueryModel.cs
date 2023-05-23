using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialBlog.Core.Services.Post.Models
{
	public class AllPostsQueryModel
	{
		public const int PostsPerPage = 3;

		[Display(Name = "Search")]
		public string? SearchTerm { get; init; }

		public int CurrentPage { get; init; } = 1;

		public int TotalPostsCount { get; set; }


		public IEnumerable<PostAllViewModel> Posts { get; set; }
			= new List<PostAllViewModel>();
	}
}
