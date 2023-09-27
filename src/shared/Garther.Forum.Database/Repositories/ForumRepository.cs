using Garther.Forum.Database.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Garther.Forum.Database.Repositories;

public class ForumRepository : IForumRepository
{
    private readonly ForumDbContext _forumDbContext;
    private readonly ILogger<ForumRepository> _logger;

    public ForumRepository(ILogger<ForumRepository> logger, ForumDbContext forumDbContext)
    {
        _logger = logger;
        _forumDbContext = forumDbContext;
    }
    
    public Task<bool> ForumExists(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Entities.Forum> CreateForumAsync(Guid id, string title, Guid userId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IEnumerable<Entities.Forum>>> GetForumsAsync(Guid id)
    {
        throw new NotImplementedException(); 
    }
}