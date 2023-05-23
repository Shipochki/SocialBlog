using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBlog.Core.Services.Author.Models
{
    public class AllAuthorViewModel
    {
        public IEnumerable<AdminAuthorViewModel> Authors { get; set; } = new List<AdminAuthorViewModel>();
    }
}
