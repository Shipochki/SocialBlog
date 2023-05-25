namespace SocialBlog.Tests.UnitTests
{
	using SocialBlog.Core.Services.Author;

	[TestFixture]
	public class AuthorServiceTests : UnitTestBase
	{
		private IAuthorService authorService;

		[OneTimeSetUp] 
		public void SetUp() 
		{
			this.authorService = new AuthorService(this.data);
		}
	}
}
