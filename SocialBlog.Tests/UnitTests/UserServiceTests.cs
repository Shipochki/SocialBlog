namespace SocialBlog.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Services.User;
	using SocialBlog.Core.Services.User.Models;

	[TestFixture]
	public class UserServiceTests
	{
		[Test]
		public async Task GetNickNameById_ShouldReturnStringUserNickName()
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

			var repo = new Repository(context);
			var userService = new UserService(repo);

			await repo.AddAsync(user);
			await repo.SaveChangesAsync();

			string result = await userService.GetNickNameById("1");

			Assert.That(result.Equals(user.NickName));
		}

		[Test]
		public async Task GetNickNameById_ShouldThorwArgumentException()
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

			var repo = new Repository(context);
			var userService = new UserService(repo);

			await repo.AddAsync(user);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await userService.GetNickNameById("2");
			});
		}

		[Test]
		public async Task GetUserProfileImgById_ShouldReturnStringWithLink()
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
				NickName = "Niki1234",
				ProfileImgLink = "Test",
			};

			var repo = new Repository(context);
			var userService = new UserService(repo);

			await repo.AddAsync(user);
			await repo.SaveChangesAsync();

			string result = await userService.GetUserProfileImgById("1");

			Assert.That(result.Equals("Test"));
		}

		[Test]
		public async Task GetUserProfileImgById_ShouldThrowArgumentException()
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
				NickName = "Niki1234",
				ProfileImgLink = "Test",
			};

			var repo = new Repository(context);
			var userService = new UserService(repo);

			await repo.AddAsync(user);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await userService.GetUserProfileImgById("2");
			});
		}

		[Test]
		public async Task GetAllUsers_ShouldReturnCollection()
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

			var repo = new Repository(context);
			var userService = new UserService(repo);

			await repo.AddAsync(user);
			await repo.SaveChangesAsync();

			List<UserViewModel> users = await userService.GetAllUsers();

			Assert.That(users.Count.Equals(1));
		}
	}
}
