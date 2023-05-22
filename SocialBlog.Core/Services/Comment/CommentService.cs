namespace SocialBlog.Core.Services.Comment
{
	using SocialBlog.Core.Services.Comment.Models;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;


	public class CommentService : ICommentService
	{
		private readonly IRepository repo;

		public CommentService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task CreateComment(CreateCommentViewModel model)
		{
			Comment comment = new Comment()
			{
				PostId = model.PostId,
				UserId = model.UserId,
				Text = model.Text,
				Created = DateTime.Now,
			};

			await this.repo.AddAsync(comment);
			await this.repo.SaveChangesAsync();
		}
	}
}
