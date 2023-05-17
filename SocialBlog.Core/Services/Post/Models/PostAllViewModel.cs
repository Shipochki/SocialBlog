namespace SocialBlog.Core.Services.Post.Models
{
    public class PostAllViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Tag { get; set; } = null!;

        public string ImageUrlLink { get; set; } = null!;

        public int TimeForRead { get; set; }

        public string Created { get; set; } = null!;

        public string AuthorFullName { get; set; } = null!;
    }
}
