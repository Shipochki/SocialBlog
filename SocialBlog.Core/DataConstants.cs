namespace SocialBlog.Core
{
    public static class DataConstants
    {
        public static class Post
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 160;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 100;

            public const int TextMinLength = 400;

            public const int TagMinLength = 3;
            public const int TagMaxLength = 20;

            public const int TimeForReadMinRange = 1;
            public const int TimeForReadMaxRange = 59;
        }

        public static class Comment
        {
            public const int TextMinLength = 1;
            public const int TextMaxLength = 200;
        }

        public static class Author
        {
            public const int PhoneNumberMinLength = 3;
            public const int PhoneNumberMaxLength = 12;
        }

        public static class User
        {
            public const int FirstNameMinLnegth = 3;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLnegth = 3;
            public const int LastNameMaxLength = 15;

            public const int NickNameMinLnegth = 3;
            public const int NickNameMaxLength = 15;
        }
    }
}
