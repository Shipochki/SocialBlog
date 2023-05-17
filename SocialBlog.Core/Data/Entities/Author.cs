namespace SocialBlog.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SocialBlog.Core.DataConstants.Author;

    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public IEnumerable<Post> Posts { get; set; } = new List<Post>();

        public bool IsActive { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }
}
