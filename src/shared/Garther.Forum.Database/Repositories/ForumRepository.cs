using AutoMapper;
using Garther.Exceptions.Database;
using Garther.Forum.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garther.Forum.Database.Repositories;

public class ForumRepository : IForumRepository
{
    private readonly ForumDbContext _forumDbContext;

    public ForumRepository(ForumDbContext forumDbContext, IMapper mapper)
    {
        _forumDbContext = forumDbContext;
    }

    public Task<bool> ForumExists(Guid id, CancellationToken token)
    {
        return  _forumDbContext.Forums.AnyAsync(forum => forum.Id.Equals(id), 
            cancellationToken: token);
    }

    public Task<Entities.Forum> GetForumById(Guid id, CancellationToken token)
    {
        return _forumDbContext.Forums.FirstAsync(forum => forum.Id.Equals(id), 
            cancellationToken: token);
    }

    public async Task<IEnumerable<Entities.Forum>> GetForums(Guid id, CancellationToken token)
    {
        return await _forumDbContext.Forums.Where(forum => forum.Id.Equals(id))
            .AsNoTracking()
            .ToArrayAsync(cancellationToken: token);
    }

    public async Task AddEntity(Entities.Forum forum, CancellationToken token)
    {
        await using var transaction = await _forumDbContext.Database.BeginTransactionAsync(token);
        
        try
        {
            await _forumDbContext.Forums.AddAsync(forum, token);
            await _forumDbContext.SaveChangesAsync(token);
            await transaction.CommitAsync(token);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(token);
            throw new CreateEntityException(forum);
        }
    }
}