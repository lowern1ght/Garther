using Garther.Forum.Database.Entities;

namespace Garther.Forum.Database.Repositories.Interfaces;

public interface ITopicRepository
{
    Task AddTopicAsync(Topic topic, CancellationToken token);
    Task<IEnumerable<Topic>> GetTopicsInForumAsync(Guid forumId, CancellationToken token);
}