namespace SocialBlog.Core.Services.Post
{
    using SocialBlog.Core.Common;
    using SocialBlog.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using SocialBlog.Core.Services.Post.Models;

    public class PostService : IPostService
    {
        private IRepository repo;

        public PostService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<AllPostsViewModel> All()
        {
            List<PostAllViewModel> posts = await repo.All<Post>()
                .Where(p => !p.IsDeleted)
                .Select(m => new PostAllViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Tag = m.Tag,
                    ImageUrlLink = m.ImageUrlLink,
                    AuthorFullName = $"{m.Author.User.FirstName} {m.Author.User.FirstName}",
                    Created = m.Created.ToString("MM/dd/yyyy"),
                    TimeForRead = m.TimeForRead,
                })
                .ToListAsync();

            AllPostsViewModel model = new AllPostsViewModel();
            model.PostsCount = posts.Count;
            model.Posts = posts;

            return model;
        }
    }
}
