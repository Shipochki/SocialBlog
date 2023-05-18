namespace SocialBlog.Core.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SocialBlog.Core.DataConstants.User;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(NickNameMaxLength)]
        public string NickName { get; set; } = null!;

        public string? ProfileImgLink { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
