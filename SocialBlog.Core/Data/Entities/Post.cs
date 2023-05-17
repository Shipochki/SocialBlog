namespace SocialBlog.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SocialBlog.Core.DataConstants.Post;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Text { get; set; } = null!;

        [Required]
        [MaxLength(TagMaxLength)]
        public string Tag { get; set; } = null!;

        [Required]
        public string ImageUrlLink { get; set; } = null!;

        [Required]
        public int TimeForRead { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        public bool IsDeleted { get; set; } = false;

    }
}
