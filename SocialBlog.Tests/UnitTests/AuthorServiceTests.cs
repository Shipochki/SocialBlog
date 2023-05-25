namespace SocialBlog.Tests.UnitTests
{
	using Moq;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Services.Author;
	using SocialBlog.Core.Services.Author.Models;

	[TestFixture]
	public class AuthorServiceTests : UnitTestBase
	{
		private IRepository repo;
		private IAuthorService authorService;

		[OneTimeSetUp] 
		public void SetUp() 
		{

		}

		[Test]
		public void GetAuthorFullNameById_ShouldReturnCorrectData()
		{
			var repoMock = new Mock<IRepository>();

			IQueryable<Author> authors = new List<Author>()
			{
				new Author() 
				{ 
					Id = 1, 
					PhoneNumber = "08235235235",
					User = new User() 
					{ 
						Id = "NikiId", 
						FirstName = "Nikola", 
						LastName = "Petrov" } },
				new Author() 
				{ 
					Id = 2, 
					PhoneNumber = "53643233523", 
					User = new User() 
					{ 
						Id = "StefiId", 
						FirstName = "Stefaini", 
						LastName = "Ivanova" 
					} 
				},
				new Author() 
				{ 
					Id = 3, 
					PhoneNumber = "63467344453",
					User = new User() 
					{ 
						Id = "ViktorId", 
						FirstName = "Viktor", 
						LastName = "Bankov" 
					} 
				},
			}
			.AsQueryable();

			repoMock
				.Setup(r => r.All<Author>())
				.Returns(authors);

			this.repo = repoMock.Object;

			this.authorService = new AuthorService(this.repo);

			var result = this.repo.All<Author>().FirstOrDefault(a => a.Id == 1);

			Assert.IsNotNull(result);

			Assert.That(result.User.FirstName.Equals("Nikola"));
		}
	}
}
