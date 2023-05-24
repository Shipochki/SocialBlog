namespace SocialBlog.Core.Services.Post
{
    using SocialBlog.Core.Data.Common;
    using SocialBlog.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using SocialBlog.Core.Services.Post.Models;
    using SocialBlog.Core.Services.Author;
    using SocialBlog.Core.Services.Author.Models;
    using SocialBlog.Core.Services.Favorite;
    using SocialBlog.Core.Services.Comment;

    public class PostService : IPostService
    {
        private readonly IRepository repo;
        private readonly IAuthorService authorService;
        private readonly IFavoriteService favoriteService;
        private readonly ICommentService commentService;

        public PostService(IRepository _repo, 
            IAuthorService authorService,
            IFavoriteService favoriteService,
            ICommentService commentService)
        {
            this.repo = _repo;
            this.authorService = authorService;
            this.favoriteService = favoriteService;
            this.commentService = commentService;
        }

        public async Task<PostQueryServiceModel> All(
            string searchTerm = null, 
            int currentPage = 1, 
            int postPerPage = 1)
        {
            IQueryable<Post> postsQuery = this.repo.All<Post>()
                .OrderByDescending(c => c.Created)
                .AsQueryable();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				postsQuery = postsQuery.Where(h =>
				h.Title.ToLower().Contains(searchTerm.ToLower()) ||
				h.Tag.ToLower().Contains(searchTerm.ToLower()) ||
				h.Description.ToLower().Contains(searchTerm.ToLower()) ||
				h.Text.ToLower().Contains(searchTerm.ToLower()));
			}

            List<PostAllViewModel> posts = await postsQuery
                .Skip((currentPage - 1) * postPerPage)
                .Where(p => p.IsDeleted == false)
                .Take(postPerPage)
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

            int totalPosts = postsQuery.Count();

            PostQueryServiceModel model = new PostQueryServiceModel();
            model.TotalPostsCount = totalPosts;
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

            await this.repo.AddAsync(post);

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

		public async Task<List<DetailsSimilarPostViewModel>> GetAllPostsIdsWithSimilarTag(string tag)
		{
            List<DetailsSimilarPostViewModel> posts = await this.repo.All<Post>()
                .Where(p => p.Tag == tag && p.IsDeleted == false)
                .OrderBy(p => p.Created)
                .Select(p => new DetailsSimilarPostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                })
                .Take(7)
                .ToListAsync();

            return posts;
		}

		public async Task<List<PostAllViewModel>> GetTopThreeFavoritePosts()
		{
            List<int> topIds = await this.favoriteService.GetTopThreeFavoritePostsIds();

            List<Post> posts = await this.repo.All<Post>()
                .Include(p => p.Author)
                .ThenInclude(p => p.User)
				.Where(p => !p.IsDeleted && topIds.Contains(p.Id))
				.ToListAsync();

			List<PostAllViewModel> viewPosts = new List<PostAllViewModel>();

            foreach (var id in topIds)
            {
                foreach (var post in posts)
                {
                    if(post.Id == id)
                    {
                        viewPosts.Add(new PostAllViewModel()
                        {
                            Id = post.Id,
                            Title = post.Title,
                            Description = post.Description,
                            Tag = post.Tag,
                            ImageUrlLink = post.ImageUrlLink,
                            AuthorFullName = $"{post.Author.User.FirstName} {post.Author.User.LastName}",
                            Created = post.Created.ToString("MM/dd/yyyy"),
                            TimeForRead = post.TimeForRead,
                        });
                        break;
                    }
                }
            }

            return viewPosts;
		}

		public async Task<List<PostAllViewModel>> GetTopThreeCommentPosts()
		{
			List<int> topIds = await this.commentService.GetTopThreeCommentPostsIds();

			List<Post> posts = await this.repo.All<Post>()
				.Include(p => p.Author)
				.ThenInclude(p => p.User)
				.Where(p => !p.IsDeleted && topIds.Contains(p.Id))
				.ToListAsync();

			List<PostAllViewModel> viewPosts = new List<PostAllViewModel>();

			foreach (var id in topIds)
			{
				foreach (var post in posts)
				{
					if (post.Id == id)
					{
						viewPosts.Add(new PostAllViewModel()
						{
							Id = post.Id,
							Title = post.Title,
							Description = post.Description,
							Tag = post.Tag,
							ImageUrlLink = post.ImageUrlLink,
							AuthorFullName = $"{post.Author.User.FirstName} {post.Author.User.LastName}",
							Created = post.Created.ToString("MM/dd/yyyy"),
							TimeForRead = post.TimeForRead,
						});
						break;
					}
				}
			}

			return viewPosts;
		}

		public async Task<List<PostAllViewModel>> GetAllPosts()
		{
            List<PostAllViewModel> posts = await this.repo
                .All<Post>()
                .Select(c => new PostAllViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Tag = c.Tag,
                    ImageUrlLink = c.ImageUrlLink,
                    AuthorFullName = $"{c.Author.User.FirstName} {c.Author.User.LastName}",
                    Created = c.Created.ToString("MM/dd/yyyy"),
                    TimeForRead = c.TimeForRead,
                })
                .ToListAsync();

            return posts;
		}
	}
}
