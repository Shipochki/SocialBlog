namespace SocialBlog.Tests.UnitTests
{
	using SocialBlog.Core;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Tests.Mocks;

	public class UnitTestBase
	{
		protected IRepository data;

		[OneTimeSetUp]
		public async void SetUpBase()
		{
			this.data = DatabaseMock.Repo;
			await SeedDatabase();
		}

		public User User { get; private set; }

		public Author Author { get; private set; }

		public Post Post { get; private set; }

		public Favorite Favorite { get; private set; }

		public Comment Comment { get; private set; }

		private async Task SeedDatabase()
		{
			this.User = new User()
			{
				Id = "StefiId",
				Email = "test@abv.bg",
				FirstName = "Stefani",
				LastName = "Ivanova",
				NickName = "Stefito",
				ProfileImgLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1f/Woman_1.jpg/768px-Woman_1.jpg",
			};
			await this.data.AddAsync<User>(this.User);

			this.Author = new Author()
			{
				Id = 1,
				PhoneNumber = "+359111111111",
				User = new User()
				{
					Id = "TestUserId",
					Email = "test@test.bg",
					FirstName = "Nikola",
					LastName = "Petrov",
					NickName = "Niki2135",
					ProfileImgLink = "https://m.media-amazon.com/images/M/MV5BZDljODI5Y2ItZjg3ZC00MWMzLTg3MzUtZDMyZWFkYzE3OWQ5XkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_.jpg",
				},
				IsActive = true
			};
			await this.data.AddAsync<Author>(this.Author);

			this.Post = new Post()
			{
				Id = 1,
				Title = "Renewable Energy",
				Description = "Desctiption",
				Text = "Text",
				Tag = "Tag",
				ImageUrlLink = "ImgLink",
				TimeForRead = 4,
				AuthorId = 1,
				Created = DateTime.Now,
				Updated = DateTime.Now,
			};
			await this.data.AddAsync<Post>(this.Post);

			this.Favorite = new Favorite()
			{
				Id = 1,
				UserId = "StefiId",
				PostId = 1,
			};
			await this.data.AddAsync<Favorite>(this.Favorite);

			this.Comment = new Comment()
			{
				Id = 1,
				PostId = 1,
				UserId = "StefiId",
				Text = "Text",
				Created = DateTime.Now,
			};
			await this.data.AddAsync<Comment>(this.Comment);

			await this.data.SaveChangesAsync();
		}

		[OneTimeTearDown]
		public void TearDownBase()
		{
			this.data.Dispose();
		}
	}
}
