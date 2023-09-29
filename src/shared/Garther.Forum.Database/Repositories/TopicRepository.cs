using AutoMapper;
using Garther.Exceptions.Database;
using Garther.Forum.Database.Entities;
using Garther.Forum.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garther.Forum.Database.Repositories;

public class TopicRepository : ITopicRepository
{
    private readonly ForumDbContext _forumDbContext;

    public TopicRepository(ForumDbContext forumDbContext, IMapper mapper)
    {
        _forumDbContext = forumDbContext;
    }

    public async Task AddEntity(Topic topic, CancellationToken token)
    {
        await using var transaction = await _forumDbContext.Database.BeginTransactionAsync(token);

        try
        {
            await _forumDbContext.Topics.AddAsync(topic, token);
            await _forumDbContext.SaveChangesAsync(token);
            await transaction.CommitAsync(token);
        }
        catch (Exception)
        {
            throw new CreateEntityException(topic);
        }
    }
    
    public async Task<IEnumerable<Topic>> GetTopicsByForum(Guid forumId, CancellationToken token)
    {
        return await _forumDbContext.Topics.Where(topic => topic.ForumId.Equals(forumId))
            .AsNoTracking()
            .ToArrayAsync(cancellationToken: token);
    }
}