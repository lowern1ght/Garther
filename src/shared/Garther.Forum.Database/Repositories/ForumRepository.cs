using AutoMapper;
using Garther.Exceptions.Database;
using Garther.Forum.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Garther.Forum.Database.Repositories;

public class ForumRepository : IForumRepository
{
    private readonly IMapper _mapper;
    private readonly ForumDbContext _forumDbContext;

    public ForumRepository(ForumDbContext forumDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _forumDbContext = forumDbContext;
    }

    public Task<bool> ForumExistsAsync(Guid id, CancellationToken token)
    {
        return  _forumDbContext.Forums.AnyAsync(forum => forum.Id.Equals(id), 
            cancellationToken: token);
    }

    public Task<Entities.Forum> GetForumByIdAsync(Guid id, CancellationToken token)
    {
        return _forumDbContext.Forums.FirstAsync(forum => forum.Id.Equals(id), 
            cancellationToken: token);
    }

    public async Task CreateForumAsync(Entities.Forum forum, CancellationToken token)
    {
        await using var transaction = await _forumDbContext.Database.BeginTransactionAsync(token);
        
        try
        {
            await _forumDbContext.Forums.AddAsync(forum, token);
            await transaction.CommitAsync(token);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(token);
            throw new CreateEntityException($"Fail to commit new entity {typeof(Entities.Forum)}");
        }
    }

    public Task<IEnumerable<IEnumerable<Entities.Forum>>> GetForumByIdAsync(Guid id, int count, int skip, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}