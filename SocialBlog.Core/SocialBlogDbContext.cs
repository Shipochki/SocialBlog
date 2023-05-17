namespace SocialBlog.Core
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SocialBlog.Core.Data.Entities;

    public class SocialBlogDbContext : IdentityDbContext<User>
    {
        public SocialBlogDbContext(DbContextOptions<SocialBlogDbContext> options)
            : base(options) 
        {
            this.Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Favorite> Favorites { get; set; }


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

            base.OnModelCreating(builder);
        }
    }
}
