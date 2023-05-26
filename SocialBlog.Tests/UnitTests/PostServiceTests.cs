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
		public async Task GetEditPostById_ShouldReturnEditViewModel()
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

			EditPostViewModel reuslt = await postService.GetEditPostById(1);

			Assert.That(reuslt.Title.Equals(posts.First().Title));
		}

		[Test]
		public async Task GetEditPostById_ShouldThrowArgumentException()
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
				await postService.GetEditPostById(5);
			});
		}

		[Test]
		public async Task EditPost_ShouldReturnIntId()
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

		[Test]
		public async Task DeletePost_ShouldSetIsDeleteToTrue()
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

			await postService.DeletePost(1);

			Assert.IsTrue(posts.First().IsDeleted);
		}

		[Test]
		public async Task DeletePost_ShouldThrowArgumentExcepiton()
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
				await postService.DeletePost(5);
			});
		}

		[Test]
		public async Task GetPostDeleteViweById_ShouldReturnDeleteModel()
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

			PostDeleteViewModel result = await postService.GetPostDeleteViweById(1);

			Assert.That(result.Id.Equals(posts.First().Id));
		}

		[Test]
		public async Task GetPostDeleteViweById_ShouldThrowArgumentException()
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
				await postService.GetPostDeleteViweById(5);
			});
		}

		[Test]
		public async Task GetAllPostsByAuthorId_ShouldReturnCollectionOfViewModels()
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

			List<PostAllViewModel> reuslt = await postService.GetAllPostsByAuthorId(1);

			Assert.That(reuslt.Count.Equals(3));
		}

		[Test]
		public async Task GetAllPostsIdsWithSimilarTag_ShouldReturnCollection()
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

			List<DetailsSimilarPostViewModel> result = await postService.GetAllPostsIdsWithSimilarTag("Tag");

			Assert.That(result.Count.Equals(1));
		}

		[Test]
		public async Task GetTopThreeFavoritePosts_ShouldReturnCollection()
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

			List<Favorite> favorites = new List<Favorite>
			{
				new Favorite {
					Id = 1,
					PostId = 1,
					UserId = "1"
				},
				new Favorite {
					Id = 2,
					PostId = 1,
					UserId = "2"
				},
				new Favorite {
					Id = 3,
					PostId = 1,
					UserId = "3"
				},
				new Favorite {
					Id = 4,
					PostId = 2,
					UserId = "1"
				},
				new Favorite {
					Id = 5,
					PostId = 3,
					UserId = "2"
				},
				new Favorite {
					Id = 6,
					PostId = 3,
					UserId = "2"
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
			await repo.AddRangeAsync(favorites);
			await repo.SaveChangesAsync();

			List<PostAllViewModel> result = await postService.GetTopThreeFavoritePosts();

			Assert.That(result[0].Id.Equals(1));
			Assert.That(result[1].Id.Equals(3));
			Assert.That(result[2].Id.Equals(2));
		}

		[Test]
		public async Task GetTopThreeCommentPosts_ShouldReturnCollection()
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

			List<Comment> comments = new List<Comment>()
			{
				new Comment
				{
					PostId = 1,
					UserId = "1",
					Text = "Text1"
				},
				new Comment
				{
					PostId = 2,
					UserId = "1",
					Text= "Text2"
				},
				new Comment
				{
					PostId = 2,
					UserId = "1",
					Text= "Text3"
				},
				new Comment
				{
					PostId = 1,
					UserId = "1",
					Text = "Text4"
				},
				new Comment
				{
					PostId = 3,
					UserId = "1",
					Text= "Text5"
				},
				new Comment
				{
					PostId = 3,
					UserId = "1",
					Text= "Text6"
				},
				new Comment
				{
					PostId = 1,
					UserId = "1",
					Text = "Text1"
				},
				new Comment
				{
					PostId = 2,
					UserId = "1",
					Text= "Text2"
				},
				new Comment
				{
					PostId = 2,
					UserId = "1",
					Text= "Text3"
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
			await repo.AddRangeAsync(comments);
			await repo.SaveChangesAsync();

			List<PostAllViewModel> result = await postService.GetTopThreeCommentPosts();

			Assert.That(result[0].Id.Equals(2));
			Assert.That(result[1].Id.Equals(1));
			Assert.That(result[2].Id.Equals(3));
		}

		[Test]
		public async Task GetAllPosts_ShouldReturnCollection()
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
					IsDeleted = true
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

			List<PostAllViewModel> result = await postService.GetAllPosts();

			Assert.That(result.Count.Equals(3));
		}
	}
}
