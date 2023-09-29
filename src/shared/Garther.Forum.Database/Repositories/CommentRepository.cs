using Garther.Exceptions.Database;
using Garther.Forum.Database.Entities;
using Garther.Forum.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garther.Forum.Database.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ForumDbContext _forumDbContext;

    public CommentRepository(ForumDbContext forumDbContext)
    {
        _forumDbContext = forumDbContext;
    }
    
    public async Task AddEntity(Comment comment, CancellationToken token)
    {
        await using var transaction = await _forumDbContext.Database.BeginTransactionAsync(token);
        
        try
        {
            await _forumDbContext.Comments.AddAsync(comment, token);
            await _forumDbContext.SaveChangesAsync(token);
            await transaction.CommitAsync(token);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(token);
            throw new CreateEntityException(comment);
        }
    }

    public async Task<Comment> GetCommentById(Guid id, CancellationToken token)
    {
        return await _forumDbContext.Comments
            .FirstAsync(comment => comment.Id.Equals(id), cancellationToken: token);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByUser(Guid userId, CancellationToken token)
    {
        return (await _forumDbContext.User
            .Include(user => user.Comments)
            .FirstAsync(user => user.Id.Equals(userId), cancellationToken: token))
            .Comments;
    }

    public async Task<IEnumerable<Comment>> GetCommentsByTopic(Guid topicId, CancellationToken token)
    {
        return (await _forumDbContext.Topics
            .Include(topic => topic.Comments)
            .FirstAsync(topic => topic.Id.Equals(topicId), token))
            .Comments;
    }
}