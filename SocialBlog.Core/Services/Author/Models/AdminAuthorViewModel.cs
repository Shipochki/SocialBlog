﻿namespace SocialBlog.Core.Services.Author.Models
{
    public class AdminAuthorViewModel
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string UserFirstName { get; set; } = null!;

        public string UserLastName { get; set; } = null!;

        public string UserNickName { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
