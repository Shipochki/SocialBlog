namespace SocialBlog.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Services.Post;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Services.Author;
	using SocialBlog.Core.Services.Favorite;
	using SocialBlog.Core.Services.Comment;
	using SocialBlog.Core.Services.Post.Models;

	[TestFixture]
	public class PostServiceTests
	{
		[Test]
		public async Task All_ShouldReturnModelWithCollection()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			List<User> users = new List<User>()
			{
				new User
				{
					Id = "1",
					FirstName = "Nikola",
					LastName = "Petrov",
					NickName = "Niki1234"
				},
				new User
				{
					Id = "2",
					FirstName = "Nikola2",
					LastName = "Petrov2",
					NickName = "Niki12342"
				}
				,
				new User
				{
					Id = "3",
					FirstName = "Nikola3",
					LastName = "Petrov3",
					NickName = "Niki124542"
				}
			};

			Author author = new Author
			{
				Id = 1,
				UserId = "1",
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>()
			{
				new Post
				{
					Id = 1,
					Title = "Title",
					Description = "Description",
					Text = "Text",
					Tag = "Tag",
					ImageUrlLink = "ImageUrlLink",
					TimeForRead = 4,
					AuthorId = 1,
				},
				new Post
				{
					Id = 2,
					Title = "Title2",
					Description = "Description2",
					Text = "Text2",
					Tag = "Tag2",
					ImageUrlLink = "ImageUrlLink2",
					TimeForRead = 6,
					AuthorId = 1,
				},
				new Post
				{
					Id = 3,
					Title = "Title3",
					Description = "Description3",
					Text = "Text3",
					Tag = "Tag3",
					ImageUrlLink = "ImageUrlLink3",
					TimeForRead = 7,
					AuthorId = 1,
				}
			};


			var repo = new Repository(context);
			var authorService = new AuthorService(repo);
			var favoriteService = new FavoriteService(repo);
			var commentService = new CommentService(repo);
			var postService = new PostService(repo, authorService, favoriteService, commentService);

			await repo.AddRangeAsync(users);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.SaveChangesAsync();

			PostQueryServiceModel reuslt = await postService.All(null, 1, 3);

			Assert.That(reuslt.TotalPostsCount.Equals(3));
		}

		[Test]
		public async Task GetDetailsPostById_ShouldReturnPostViewModel()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			List<User> users = new List<User>()
			{
				new User
				{
					Id = "1",
					FirstName = "Nikola",
					LastName = "Petrov",
					NickName = "Niki1234"
				},
				new User
				{
					Id = "2",
					FirstName = "Nikola2",
					LastName = "Petrov2",
					NickName = "Niki12342"
				}
				,
				new User
				{
					Id = "3",
					FirstName = "Nikola3",
					LastName = "Petrov3",
					NickName = "Niki124542"
				}
			};

			Author author = new Author
			{
				Id = 1,
				UserId = "1",
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>()
			{
				new Post
				{
					Id = 1,
					Title = "Title",
					Description = "Description",
					Text = "Text",
					Tag = "Tag",
					ImageUrlLink = "ImageUrlLink",
					TimeForRead = 4,
					AuthorId = 1,
				},
				new Post
				{
					Id = 2,
					Title = "Title2",
					Description = "Description2",
					Text = "Text2",
					Tag = "Tag2",
					ImageUrlLink = "ImageUrlLink2",
					TimeForRead = 6,
					AuthorId = 1,
				},
				new Post
				{
					Id = 3,
					Title = "Title3",
					Description = "Description3",
					Text = "Text3",
					Tag = "Tag3",
					ImageUrlLink = "ImageUrlLink3",
					TimeForRead = 7,
					AuthorId = 1,
				}
			};

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);
			var favoriteService = new FavoriteService(repo);
			var commentService = new CommentService(repo);
			var postService = new PostService(repo, authorService, favoriteService, commentService);

			await repo.AddRangeAsync(users);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.SaveChangesAsync();

			DetailsPostViewModel result = await postService.GetDetailsPostById(1);

			Assert.IsNotNull(result);

			Assert.That(posts.First().Title.Equals(result.Title));
		}

		[Test]
		public async Task GetDetailsPostById_ShouldThrowArgumentException()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			List<User> users = new List<User>()
			{
				new User
				{
					Id = "1",
					FirstName = "Nikola",
					LastName = "Petrov",
					NickName = "Niki1234"
				},
				new User
				{
					Id = "2",
					FirstName = "Nikola2",
					LastName = "Petrov2",
					NickName = "Niki12342"
				}
				,
				new User
				{
					Id = "3",
					FirstName = "Nikola3",
					LastName = "Petrov3",
					NickName = "Niki124542"
				}
			};

			Author author = new Author
			{
				Id = 1,
				UserId = "1",
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>()
			{
				new Post
				{
					Id = 1,
					Title = "Title",
					Description = "Description",
					Text = "Text",
					Tag = "Tag",
					ImageUrlLink = "ImageUrlLink",
					TimeForRead = 4,
					AuthorId = 1,
				},
				new Post
				{
					Id = 2,
					Title = "Title2",
					Description = "Description2",
					Text = "Text2",
					Tag = "Tag2",
					ImageUrlLink = "ImageUrlLink2",
					TimeForRead = 6,
					AuthorId = 1,
				},
				new Post
				{
					Id = 3,
					Title = "Title3",
					Description = "Description3",
					Text = "Text3",
					Tag = "Tag3",
					ImageUrlLink = "ImageUrlLink3",
					TimeForRead = 7,
					AuthorId = 1,
				}
			};

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);
			var favoriteService = new FavoriteService(repo);
			var commentService = new CommentService(repo);
			var postService = new PostService(repo, authorService, favoriteService, commentService);

			await repo.AddRangeAsync(users);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await postService.GetDetailsPostById(5);
			});
		}

		[Test]
		public async Task CreatePost_ShouldReturnIntId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			List<User> users = new List<User>()
			{
				new User
				{
					Id = "1",
					FirstName = "Nikola",
					LastName = "Petrov",
					NickName = "Niki1234"
				},
				new User
				{
					Id = "2",
					FirstName = "Nikola2",
					LastName = "Petrov2",
					NickName = "Niki12342"
				}
				,
				new User
				{
					Id = "3",
					FirstName = "Nikola3",
					LastName = "Petrov3",
					NickName = "Niki124542"
				}
			};

			Author author = new Author
			{
				Id = 1,
				UserId = "1",
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>()
			{
				new Post
				{
					Id = 1,
					Title = "Title",
					Description = "Description",
					Text = "Text",
					Tag = "Tag",
					ImageUrlLink = "ImageUrlLink",
					TimeForRead = 4,
					AuthorId = 1,
				},
				new Post
				{
					Id = 2,
					Title = "Title2",
					Description = "Description2",
					Text = "Text2",
					Tag = "Tag2",
					ImageUrlLink = "ImageUrlLink2",
					TimeForRead = 6,
					AuthorId = 1,
				},
				new Post
				{
					Id = 3,
					Title = "Title3",
					Description = "Description3",
					Text = "Text3",
					Tag = "Tag3",
					ImageUrlLink = "ImageUrlLink3",
					TimeForRead = 7,
					AuthorId = 1,
				}
			};


			var repo = new Repository(context);
			var authorService = new AuthorService(repo);
			var favoriteService = new FavoriteService(repo);
			var commentService = new CommentService(repo);
			var postService = new PostService(repo, authorService, favoriteService, commentService);

			await repo.AddRangeAsync(users);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.SaveChangesAsync();

			CreatePostViewModel model = new CreatePostViewModel
			{
				Title = "Title",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				TimeForRead = 7,
				AuthorId = 1,
				ImageUrlLink = "ImgLink",
			};

			int result = await postService.CreatePost(model);

			Assert.That(result.Equals(4));
		}

		[Test]
		public async Task GetEditPostById_ShouldReturnIntId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			List<User> users = new List<User>()
			{
				new User
				{
					Id = "1",
					FirstName = "Nikola",
					LastName = "Petrov",
					NickName = "Niki1234"
				},
				new User
				{
					Id = "2",
					FirstName = "Nikola2",
					LastName = "Petrov2",
					NickName = "Niki12342"
				}
				,
				new User
				{
					Id = "3",
					FirstName = "Nikola3",
					LastName = "Petrov3",
					NickName = "Niki124542"
				}
			};

			Author author = new Author
			{
				Id = 1,
				UserId = "1",
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>()
			{
				new Post
				{
					Id = 1,
					Title = "Title",
					Description = "Description",
					Text = "Text",
					Tag = "Tag",
					ImageUrlLink = "ImageUrlLink",
					TimeForRead = 4,
					AuthorId = 1,
				},
				new Post
				{
					Id = 2,
					Title = "Title2",
					Description = "Description2",
					Text = "Text2",
					Tag = "Tag2",
					ImageUrlLink = "ImageUrlLink2",
					TimeForRead = 6,
					AuthorId = 1,
				},
				new Post
				{
					Id = 3,
					Title = "Title3",
					Description = "Description3",
					Text = "Text3",
					Tag = "Tag3",
					ImageUrlLink = "ImageUrlLink3",
					TimeForRead = 7,
					AuthorId = 1,
				}
			};


			var repo = new Repository(context);
			var authorService = new AuthorService(repo);
			var favoriteService = new FavoriteService(repo);
			var commentService = new CommentService(repo);
			var postService = new PostService(repo, authorService, favoriteService, commentService);

			await repo.AddRangeAsync(users);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.SaveChangesAsync();

			EditPostViewModel model = new EditPostViewModel
			{
				Id = 1,
				Title = "TitleEdit",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				TimeForRead = 7,
				AuthorId = 1,
				ImageUrlLink = "ImgLink",
			};

			await postService.EditPost(model);

			Assert.That(posts.First().Title.Equals("TitleEdit"));
		}
	}
}
