namespace SocialBlog.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Services.Favorite.Models;
	using SocialBlog.Core.Services.Favorite;

	[TestFixture]
	public class FavoriteServiceTests
	{
		[Test]
		public async Task CreateFavorite_ShouldAddFavoriteToDatabase()
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
			var favoriteService = new FavoriteService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.SaveChangesAsync();

			CreateFavoriteViewModel model = new CreateFavoriteViewModel()
			{
				PostId = post.Id,
				UserId = user.Id,
			};

			await favoriteService.CreateFavorite(model);

			Favorite result = await repo.GetByIdAsync<Favorite>(1);

			Assert.IsNotNull(result);

			Assert.That(result.UserId.Equals(user.Id));
			
			Assert.That(result.PostId.Equals(post.Id));
		}

		[Test]
		public async Task CreateFavorite_ShouldNotAddFavoriteToDatabase()
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
			var favoriteService = new FavoriteService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.SaveChangesAsync();

			CreateFavoriteViewModel model = new CreateFavoriteViewModel()
			{
				PostId = post.Id,
				UserId = user.Id,
			};

			await favoriteService.CreateFavorite(model);
			await favoriteService.CreateFavorite(model);

			List<Favorite> result = await repo.All<Favorite>().ToListAsync();

			Assert.That(result.Count.Equals(1));
		}

		[Test]
		public async Task GetAllFavoriteByUserId_ShouldReturnCollection()
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

			Favorite favorite = new Favorite
			{
				Id = 1,
				PostId = 1,
				UserId = "1"
			};

			var repo = new Repository(context);
			var favoriteService = new FavoriteService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.AddAsync(favorite);
			await repo.SaveChangesAsync();

			List<FavoriteAllViewModel> reuslt = await favoriteService.GetAllFavoriteByUserId("1");

			Assert.That(reuslt.Count.Equals(1));
		}

		[Test]
		public async Task Delete_ShouldDeleteFavoriteById()
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

			Favorite favorite = new Favorite
			{
				Id = 1,
				PostId = 1,
				UserId = "1"
			};

			var repo = new Repository(context);
			var favoriteService = new FavoriteService(repo);

			await repo.AddAsync(user);
			await repo.AddAsync(author);
			await repo.AddAsync(post);
			await repo.AddAsync(favorite);
			await repo.SaveChangesAsync();

			await favoriteService.Delete(1);

			Favorite result = await repo.GetByIdAsync<Favorite>(1);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetTopThreeFavoritePostsIds_ShouldReturnCollectionOfIds()
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
			var favoriteService = new FavoriteService(repo);

			await repo.AddRangeAsync(users);
			await repo.AddAsync(author);
			await repo.AddRangeAsync(posts);
			await repo.AddRangeAsync(favorites);
			await repo.SaveChangesAsync();

			List<int> result = await favoriteService.GetTopThreeFavoritePostsIds();

			Assert.That(result[0].Equals(1));
			Assert.That(result[1].Equals(3));
			Assert.That(result[2].Equals(2));
		}
	}
}
