namespace SocialBlog.Core.Services.Comment
{
	using SocialBlog.Core.Services.Comment.Models;
	using SocialBlog.Core.Data.Common;
	using SocialBlog.Core.Data.Entities;
	using System.Collections.Generic;
	using Microsoft.EntityFrameworkCore;

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

		public async Task<int> DeleteComment(int id)
		{
			Comment comment = await this.repo.GetByIdAsync<Comment>(id);

			comment.IsDeleted = true;

			await this.repo.SaveChangesAsync();

			return comment.PostId;
		}

		public async Task<List<CommentViewModel>> GetAllCommentByPostId(int postId)
		{
			List<CommentViewModel> models = await this.repo
				.All<Comment>()
				.OrderBy(c => c.Created)
				.Where(c => c.IsDeleted == false && c.PostId == postId)
				.Select(c => new CommentViewModel
				{
					Id = c.Id,
					Text = c.Text,
					UserId = c.UserId,
					Created = c.Created.ToString("MM/dd/yyyy"),
					UserNickName = c.User.NickName,
					ProfileImgLink = c.User.ProfileImgLink != null ? c.User.ProfileImgLink : "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
				})
				.ToListAsync();
				
			return models;
		}

		public async Task<List<int>> GetTopThreeCommentPostsIds()
		{
			IEnumerable<Comment> comments = await this.repo
				.All<Comment>()
				.ToListAsync();

			Dictionary<int, int> commentsCounter = new Dictionary<int, int>();

			foreach (Comment f in comments)
			{
				if (!commentsCounter.ContainsKey(f.PostId))
				{
					commentsCounter.Add(f.PostId, 0);
				}

				commentsCounter[f.PostId]++;
			}

			Dictionary<int, int> sorted = new Dictionary<int, int>(commentsCounter.OrderByDescending(f => f.Value));

			List<int> ids = sorted.Keys.Take(3).ToList();

			return ids;
		}
	}
}
