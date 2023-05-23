namespace SocialBlog.Core.Services.Post
{
    using SocialBlog.Core.Services.Post.Models;

    public interface IPostService
    {
        Task<PostQueryServiceModel> All(string searchTerm = null, int currentPage = 1, int postPerPage = 1);

        Task<TopThreeFavoritePostsViewModel> TopThreePosts();

        Task<DetailsPostViewModel> GetDetailsPostById(int id);

        Task<int> CreatePost(CreatePostViewModel model);

        Task<EditPostViewModel> GetEditPostById(int id);

        Task EditPost(EditPostViewModel model);

        Task DeletePost(int id);

        Task<PostDeleteViewModel> GetPostDeleteViweById(int id);

        Task<AllPostsViewModel> GetAllPostsByAuthorId(int authorId);

        Task<List<DetailsSimilarPostViewModel>> GetAllPostsIdsWithSimilarTag(string tag);

        Task<List<PostAllViewModel>> GetTopThreeFavoritePosts();
		Task<List<PostAllViewModel>> GetTopThreeCommentPosts();
	}
}
