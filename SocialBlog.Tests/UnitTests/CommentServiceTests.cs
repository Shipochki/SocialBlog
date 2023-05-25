namespace SocialBlog.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core.Services.Comment;
	using SocialBlog.Core;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Services.Comment.Models;

	[TestFixture]
	public class CommentServiceTests
	{
		[Test]
		public async Task CreateComment_ShouldAddCommentToDatabase()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			Post post = new Post
			{
				Id = 1,
				Title = "Title",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				ImageUrlLink = "ImageUrlLink",
				TimeForRead = 4,
				AuthorId = 1,
			};

			var repo = new Repository(context);
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.SaveChangesAsync();

			CreateCommentViewModel model = new CreateCommentViewModel()
			{
				PostId = 1,
				UserId = "1",
				Text = "Text"
			};

			await commentService.CreateComment(model);

			List<Comment> result = await repo.All<Comment>().ToListAsync();

			Assert.That(result.Count.Equals(1));

			Assert.That(result.First().Id.Equals(1));
		}

		[Test]
		public async Task DeleteComment_ShouldSetIsDeletedToTrueAndReturnPostId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			Post post = new Post
			{
				Id = 1,
				Title = "Title",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				ImageUrlLink = "ImageUrlLink",
				TimeForRead = 4,
				AuthorId = 1,
			};

			Comment comment = new Comment()
			{
				PostId = 1,
				UserId = "1",
				Text = "Text"
			};

			var repo = new Repository(context);
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.AddAsync(comment);
			await repo.SaveChangesAsync();

			int result = await commentService.DeleteComment(1);

			Comment commentResult = await repo.GetByIdAsync<Comment>(1);

			Assert.That(result.Equals(1));

			Assert.IsTrue(commentResult.IsDeleted);
		}

		[Test]
		public async Task DeleteComment_ShouldThorwArgumentException()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			Post post = new Post
			{
				Id = 1,
				Title = "Title",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				ImageUrlLink = "ImageUrlLink",
				TimeForRead = 4,
				AuthorId = 1,
			};

			Comment comment = new Comment()
			{
				PostId = 1,
				UserId = "1",
				Text = "Text"
			};

			var repo = new Repository(context);
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.AddAsync(comment);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await commentService.DeleteComment(2);
			});
		}

		[Test]
		public async Task GetAllCommentByPostId_ShouldReturnCollectionOfCommentsByPostId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			Post post = new Post
			{
				Id = 1,
				Title = "Title",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				ImageUrlLink = "ImageUrlLink",
				TimeForRead = 4,
				AuthorId = 1,
			};

			Comment comment = new Comment()
			{
				PostId = 1,
				UserId = "1",
				Text = "Text"
			};

			var repo = new Repository(context);
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.AddAsync(comment);
			await repo.SaveChangesAsync();

			List<CommentViewModel> result = await commentService.GetAllCommentByPostId(1);

			Assert.That(result.Count.Equals(1));
		}

		[Test]
		public async Task GetAllCommentByPostId_ShouldReturnEmptyCollection()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			Post post = new Post
			{
				Id = 1,
				Title = "Title",
				Description = "Description",
				Text = "Text",
				Tag = "Tag",
				ImageUrlLink = "ImageUrlLink",
				TimeForRead = 4,
				AuthorId = 1,
			};

			Comment comment = new Comment()
			{
				PostId = 1,
				UserId = "1",
				Text = "Text"
			};

			var repo = new Repository(context);
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.AddAsync(comment);
			await repo.SaveChangesAsync();

			List<CommentViewModel> result = await commentService.GetAllCommentByPostId(2);

			Assert.That(result.Count.Equals(0));
		}

		[Test]
		public async Task GetTopThreeCommentPostsIds_ShouldReturnCollectionInInts()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>
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
					TimeForRead = 5,
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
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.AddRangeAsync(comments);
			await repo.SaveChangesAsync();

			List<int> reuslt = await commentService.GetTopThreeCommentPostsIds();

			Assert.That(reuslt[0].Equals(2));
			Assert.That(reuslt[1].Equals(1));
			Assert.That(reuslt[2].Equals(3));
		}

		[Test]
		public async Task GetAllComment_ShouldReturnCollectionOfComments()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "1",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			Author author = new Author
			{
				Id = 1,
				UserId = user.Id,
				PhoneNumber = "525252353",
			};

			List<Post> posts = new List<Post>
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
					TimeForRead = 5,
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
					Text = "Text7"
				},
				new Comment
				{
					PostId = 2,
					UserId = "1",
					Text= "Text8"
				},
				new Comment
				{
					PostId = 2,
					UserId = "1",
					Text= "Text9"
				}
			};

			var repo = new Repository(context);
			var commentService = new CommentService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.AddRangeAsync(comments);
			await repo.SaveChangesAsync();

			List<CommentViewModel> result = await commentService.GetAllComment();

			Assert.That(result.Count.Equals(9));
		}
	}
}
