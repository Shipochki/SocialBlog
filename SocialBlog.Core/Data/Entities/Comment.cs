namespace SocialBlog.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SocialBlog.Core.DataConstants.Comment;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
