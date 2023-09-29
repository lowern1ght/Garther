namespace Garther.Forum.Database.Repositories.Interfaces;

public interface IForumRepository : IAddEntity<Entities.Forum>
{
    Task<bool> ForumExists(Guid id, CancellationToken token);
    Task<Forum.Database.Entities.Forum> GetForumById(Guid id, CancellationToken token);
    Task<IEnumerable<Entities.Forum>> GetForums(Guid id, CancellationToken token);
}