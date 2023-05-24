namespace SocialBlog.Web.Models.Author
{
    using SocialBlog.Core.Services.Author.Models;

    public class AllAuthorViewModel
    {
        public IEnumerable<AdminAuthorViewModel> Authors { get; set; } = new List<AdminAuthorViewModel>();
    }
}
