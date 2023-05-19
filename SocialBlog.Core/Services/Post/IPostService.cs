namespace SocialBlog.Core.Services.Post
{
    using SocialBlog.Core.Services.Post.Models;

    public interface IPostService
    {
        Task<AllPostsViewModel> All();

        Task<TopThreeFavoritePostsViewModel> TopThreePosts();

        Task<DetailsPostViewModel> GetDetailsPostById(int id);

        Task<int> CreatePost(CreatePostViewModel model);

        Task<EditPostViewModel> GetEditPostById(int id);

        Task EditPost(EditPostViewModel model);

        Task DeletePost(int id);

        Task<PostDeleteViewModel> GetPostDeleteViweById(int id);
    }
}
