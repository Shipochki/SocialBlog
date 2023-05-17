namespace SocialBlog.Core.Services.Post.Models
{
    public class AllPostsViewModel
    {
        public int PostsCount { get; set; }

        public IEnumerable<PostAllViewModel> Posts { get; set; }
    }
}
