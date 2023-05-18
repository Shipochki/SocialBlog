namespace SocialBlog.Core.Services.Post
{
    using SocialBlog.Core.Data.Common;
    using SocialBlog.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using SocialBlog.Core.Services.Post.Models;
    using SocialBlog.Core.Services.Author;
    using SocialBlog.Core.Services.Author.Models;

    public class PostService : IPostService
    {
        private readonly IRepository repo;
        private readonly IAuthorService authorService;

        public PostService(IRepository _repo, IAuthorService authorService)
        {
            this.repo = _repo;
            this.authorService = authorService;
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
                    AuthorFullName = $"{m.Author.User.FirstName} {m.Author.User.LastName}",
                    Created = m.Created.ToString("MM/dd/yyyy"),
                    TimeForRead = m.TimeForRead,
                })
                .ToListAsync();

            AllPostsViewModel model = new AllPostsViewModel();
            model.PostsCount = posts.Count;
            model.Posts = posts;

            return model;
        }

		public async Task<DetailsPostViewModel> GetPostById(int id)
		{
            Post post = await this.repo.GetByIdAsync<Post>(id);

            if (post == null)
            {
                throw new ArgumentException("Missing Details");
            }

            AuthorFullNameViewModel author = await this.authorService.GetAuthorFullNameById(post.AuthorId);

            DetailsPostViewModel model = new DetailsPostViewModel
            {
                Title = post.Title,
                Text = post.Text,
                Tag = post.Tag,
                ImageUrlLink = post.ImageUrlLink,
                TimeForRead = post.TimeForRead,
                Created = post.Created.ToString("MM/dd/yyyy"),
                AuthorId = post.AuthorId,
                AuthorFullName = $"{author.FirstName} {author.LastName}"
			};

            return model;
		}

		public Task<TopThreeFavoritePostsViewModel> TopThreePosts()
		{
			throw new NotImplementedException();
		}
	}
}
