namespace SocialBlog.Core.Services.Post
{
    using SocialBlog.Core.Services.Post.Models;

    public interface IPostService
    {
        Task<AllPostsViewModel> All();

        Task<TopThreeFavoritePostsViewModel> TopThreePosts();

        Task<DetailsPostViewModel> GetPostById(int id);

        Task<int> CreatePost(CreatePostViewModel model);
    }
}
