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
                .OrderByDescending(p => p.Created)
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

        public async Task<int> CreatePost(CreatePostViewModel model)
        {
            Post post = new Post()
            {
                Title = model.Title,
                Description = model.Description,
                Text = model.Text,
                Tag = model.Tag,
                ImageUrlLink = model.ImageUrlLink,
                TimeForRead = model.TimeForRead,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                AuthorId = model.AuthorId,
            };

            await this.repo.AddAsync<Post>(post);

            await this.repo.SaveChangesAsync();

            return post.Id;
        }

		public async Task<EditPostViewModel> GetEditPostById(int id)
		{
			Post post = await this.repo.GetByIdAsync<Post>(id);

            if(post == null)
            {
                throw new ArgumentException($"Edit post Problem with id {id}");
            }

            EditPostViewModel model = new EditPostViewModel()
            {
                Id = id,
                Title = post.Title,
                Description = post.Description,
                Text = post.Text,
                Tag = post.Tag,
                ImageUrlLink = post.ImageUrlLink,
                TimeForRead = post.TimeForRead,
                AuthorId = post.AuthorId,
            };

            return model;
		}

		public async Task<DetailsPostViewModel> GetDetailsPostById(int id)
		{
            Post post = await this.repo.GetByIdAsync<Post>(id);

            if (post == null)
            {
                throw new ArgumentException($"Details post Problem with id {id}");
            }

            AuthorFullNameViewModel author = await this.authorService.GetAuthorFullNameById(post.AuthorId);

            DetailsPostViewModel model = new DetailsPostViewModel
            {
                Id = post.Id,
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

		public async Task EditPost(EditPostViewModel model)
		{
			Post post = await this.repo.GetByIdAsync<Post>(model.Id);

            post.Title = model.Title;
            post.Description = model.Description;
            post.Text = model.Text;
            post.Tag = model.Tag;
            post.ImageUrlLink = model.ImageUrlLink;
            post.TimeForRead = model.TimeForRead;
            post.Updated = DateTime.Now;

            await this.repo.SaveChangesAsync();
		}

		public async Task DeletePost(int id)
		{
			Post post = await this.repo.GetByIdAsync<Post>(id);

			if (post == null)
			{
				throw new ArgumentException($"Delete post problem with {id}");
			}

			post.IsDeleted = true;

            await this.repo.SaveChangesAsync();
		}

		public async Task<PostDeleteViewModel> GetPostDeleteViweById(int id)
		{
			Post post = await this.repo.GetByIdAsync<Post>(id);

            if(post == null)
            {
                throw new ArgumentException($"Get Post Delete View problem with {id}");
            }

            PostDeleteViewModel model = new PostDeleteViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                ImageUrlLink = post.ImageUrlLink,
                AuthorId = post.AuthorId,
            };

            return model;
		}

        public async Task<AllPostsViewModel> GetAllPostsByAuthorId(int authorId)
        {
            List<PostAllViewModel> posts = await repo.All<Post>()
                .Where(p => !p.IsDeleted && p.AuthorId == authorId)
                .OrderByDescending(p => p.Created)
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

		public async Task<List<int>> GetAllPostsIdsWithSimilarTag(string tag)
		{
            List<Post> posts = await this.repo.All<Post>()
                .Where(p => p.Tag == tag && p.IsDeleted == false)
                .OrderBy(p => p.Created)
                .Take(7)
                .ToListAsync();

            List<int> ids = new List<int>();

            foreach (var post in posts)
            {
                ids.Add(post.Id);
            }

            return ids;
		}
	}
}
