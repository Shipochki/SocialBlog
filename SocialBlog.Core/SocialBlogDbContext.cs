namespace SocialBlog.Core
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SocialBlog.Core.Data.Entities;

    public class SocialBlogDbContext : IdentityDbContext<User>
    {
        private User Admin { get; set; }

        private Author Author { get; set; }

        private Post Post1 { get; set; }

		private Post Post2 { get; set; }

		private Post Post3 { get; set; }

		public SocialBlogDbContext(DbContextOptions<SocialBlogDbContext> options)
            : base(options) 
        {
			if (this.Database.IsRelational())
			{
				this.Database.Migrate();
			}
			else
			{
				this.Database.EnsureCreated();
			}
		}

        public DbSet<Post> Posts { get; set; } = null!;

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Favorite> Favorites { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Author>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder 
                .Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Favorite>()
                .HasOne(f => f.Post)
                .WithMany()
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //SeedData();

            //builder
            //    .Entity<User>()
            //    .HasData(this.Admin);

            //builder
            //    .Entity<Author>()
            //    .HasData(this.Author);

            //builder
            //    .Entity<Post>()
            //    .HasData(this.Post1);

            //builder
            //    .Entity<Post>()
            //    .HasData(this.Post2);

            //builder
            //    .Entity<Post>()
            //    .HasData(this.Post3);

            base.OnModelCreating(builder);
        }

        private void SeedData()
        {
			this.Admin = new User()
			{
				Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
				Email = "admin@mail.com",
				NormalizedEmail = "admin@mail.com",
				UserName = "admin@mail.com",
				NormalizedUserName = "admin@mail.com",
				FirstName = "Owner",
				LastName = "Admin",
				NickName = "Admin",
				IsDeleted = false,
			};

            this.Post1 = new Post()
            {
                Id = 1,
                Title = "Renewable Energy",
                Description = "Explore the advancements and impact of renewable energy sources such as solar, wind, hydro",
                Text = "Explore the advancements and impact of renewable energy sources such as solar, wind, hydro, and geothermal power. Discuss their role in combating climate change, reducing carbon emissions, and creating a sustainable future.",
                Tag = "Energy",
                ImageUrlLink = "https://www.visualcapitalist.com/wp-content/uploads/2022/06/typess-of-renewable-energy.jpg",
                TimeForRead = 5,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                AuthorId = 1,
                IsDeleted = false,
			};

			this.Post2 = new Post()
			{
				Id = 2,
				Title = "Artificial Intelligence in Healthcare",
				Description = "Delve into the applications of artificial intelligence (AI).",
				Text = "Delve into the applications of artificial intelligence (AI) in healthcare, including medical diagnosis, drug discovery, personalized medicine, and patient care. Highlight the benefits, challenges, and ethical considerations surrounding the use of AI in this critical field.",
				Tag = "AI",
				ImageUrlLink = "https://online.stanford.edu/sites/default/files/styles/embedded_large/public/2020-08/artificial-intelligence-in-healthcare-MAIN.jpg?itok=uRNflQFw",
				TimeForRead = 2,
				Created = DateTime.Now,
				Updated = DateTime.Now,
				AuthorId = 1,
				IsDeleted = false,
			};

			this.Post3 = new Post()
			{
				Id = 3,
				Title = "Future of Work",
				Description = "Examine the evolving landscape of work in the digital age.",
				Text = "Examine the evolving landscape of work in the digital age, considering the impact of automation, remote work, gig economy, and emerging technologies on employment patterns and job opportunities. Discuss the skills and adaptations needed for individuals and societies to thrive in the future work environment.",
				Tag = "Work",
				ImageUrlLink = "https://www.leadingauthorities.com/sites/default/files/2019-11/the-future-of-work.details.png",
				TimeForRead = 4,
				Created = DateTime.Now,
				Updated = DateTime.Now,
				AuthorId = 1,
				IsDeleted = false,
			};

			this.Author = new Author()
            {
                Id = 1,
                PhoneNumber = "0123456789",
                UserId = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                IsActive = true,
                IsDeleted = false,
            };


			var hasher = new PasswordHasher<User>();

			this.Admin.PasswordHash =
				hasher.HashPassword(this.Admin, "admin123");
		}
    }
}
