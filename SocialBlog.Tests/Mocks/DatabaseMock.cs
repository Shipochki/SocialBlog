//namespace SocialBlog.Tests.Mocks
//{
//	using Castle.Components.DictionaryAdapter.Xml;
//	using Microsoft.EntityFrameworkCore;
//	using SocialBlog.Core;
//	using SocialBlog.Core.Data.Common;

//	public static class DatabaseMock
//	{
//		public static SocialBlogDbContext Instance
//		{
//			get
//			{
//				var dbContextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
//					.UseInMemoryDatabase("SocialBlogInMemoryDb"
//					+ DateTime.Now.Ticks.ToString())
//					.Options;

//				return new SocialBlogDbContext(dbContextOptions);
//			}
//		}
//	}
//}
