using Garther.Forum.Database.Entities;

namespace Garther.Forum.Database.Repositories.Interfaces;

public interface ITopicRepository : IAddEntity<Topic>
{
    Task<IEnumerable<Topic>> GetTopicsByForum(Guid forumId, CancellationToken token);
}