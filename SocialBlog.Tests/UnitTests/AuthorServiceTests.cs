namespace SocialBlog.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using SocialBlog.Core;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;
	using SocialBlog.Core.Services.Author;
	using SocialBlog.Core.Services.Author.Models;

	[TestFixture]
	public class AuthorServiceTests : UnitTestBase
	{
		[Test]
		public async Task GetAuthorFullNameById_ShouldReturnCorrectData()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
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
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			var result = await authorService.GetAuthorFullNameById(1);

			Assert.IsNotNull(result);

			Assert.That(result.FirstName.Equals("Nikola"));

			Assert.That(result.LastName.Equals("Petrov"));
		}

		[Test]
		public async Task GetAuthorFullNameById_ShouldThrowArgumentException()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
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
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await authorService.GetAuthorFullNameById(5);
			});
		}

		[Test]
		public async Task GetAuthorIdByUserId_ShouldReturnCorrectId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
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
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			int AuthorIdResult = await authorService.GetAuthorIdByUserId("StefiId");

			Assert.That(AuthorIdResult.Equals(2));
		}

		[Test]
		public async Task GetAuthorIdByUserId_ShouldReturnMinusOne()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
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
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			int AuthorIdResult = await authorService.GetAuthorIdByUserId("");

			Assert.That(AuthorIdResult.Equals(-1));
		}

		[Test]
		public async Task CreateAuthor_ShouldAddAuthorToDataBase()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			User user = new User
			{
				Id = "NikiId",
				FirstName = "Nikola",
				LastName = "Petrov",
				NickName = "Niki1234"
			};

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddAsync(user);
			await repo.SaveChangesAsync();

			AuthorCreateServiceModel model = new AuthorCreateServiceModel() 
			{
				UserId = user.Id,
				PhoneNumber = "36364463643"
			};

			await authorService.CreateAuthor(model);

			List<Author> result = await repo.All<Author>().ToListAsync();

			Assert.That(result.Count.Equals(1));
		}

		[Test]
		public async Task GetAllCandidate_ShouldReturnListOfMappedAuthors()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			List<AuthorCandidateViewModel> result = await authorService.GetAllCandidate();

			Assert.That(result.Count.Equals(2));
		}

		[Test]
		public async Task ApproveAuthor_ShouldSetIsActiveToTrueOnAuthorById()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			await authorService.ApproveAuthor(1);

			Author result = await repo.GetByIdAsync<Author>(1);

			Assert.IsTrue(result.IsActive);
		}

		[Test]
		public async Task ApproveAuthor_ShouldThorwArgumentExceptionWithNotCorrectId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await authorService.ApproveAuthor(5);
			});
		}

		[Test]
		public async Task Delete_ShouldSetIsDeleteToTrue()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			await authorService.Delete(1);

			Author author = await repo.GetByIdAsync<Author>(1);

			Assert.IsTrue(author.IsDeleted);
		}

		[Test]
		public async Task Delete_ShouldThorwArgumentExceptionWithNotCorrectId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await authorService.Delete(5);
			});
		}

		[Test]
		public async Task ActivevateAuthor_ShouldSetIsActiveToTrueOnAuthorById()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					},
					IsDeleted = true,
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			await authorService.ActivevateAuthor(1);

			Author result = await repo.GetByIdAsync<Author>(1);

			Assert.IsFalse(result.IsDeleted);
		}

		[Test]
		public async Task ActivevateAuthor_ShouldThorwArgumentExceptionWithNotCorrectId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await authorService.ActivevateAuthor(5);
			});
		}

		[Test]
		public async Task GetAllAuthors_ShouldReturnListOfMappedAuthors()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					}
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			List<AdminAuthorViewModel> result = await authorService.GetAllAuthors();

			Assert.That(result.Count.Equals(3));
		}

		[Test]
		public async Task DeactivateAuthor_ShouldSetIsActiveToTrueOnAuthorById()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
						LastName = "Petrov" ,
						NickName = "Niki1234"
					},
					IsDeleted = true,
				},
				new Author()
				{
					Id = 2,
					PhoneNumber = "53643233523",
					User = new User()
					{
						Id = "StefiId",
						FirstName = "Stefaini",
						LastName = "Ivanova",
						NickName = "Stefito"
					},
					IsActive = true,
				},
				new Author()
				{
					Id = 3,
					PhoneNumber = "63467344453",
					User = new User()
					{
						Id = "ViktorId",
						FirstName = "Viktor",
						LastName = "Bankov",
						NickName = "Viko"
					}
				},
			}
			.AsQueryable();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.AddRangeAsync(authors);
			await repo.SaveChangesAsync();

			await authorService.Deactivate(2);

			Author result = await repo.GetByIdAsync<Author>(2);

			Assert.IsFalse(result.IsActive);
		}

		[Test]
		public async Task DeactivateAuthor_ShouldThorwArgumentExceptionWithNotCorrectId()
		{
			var contextOptions = new DbContextOptionsBuilder<SocialBlogDbContext>()
				.UseInMemoryDatabase("SocialBlogDb")
				.Options;

			var context = new SocialBlogDbContext(contextOptions);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			var repo = new Repository(context);
			var authorService = new AuthorService(repo);

			await repo.SaveChangesAsync();

			Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await authorService.Deactivate(5);
			});
		}

	}
}
