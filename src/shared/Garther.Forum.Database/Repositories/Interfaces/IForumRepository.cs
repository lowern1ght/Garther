namespace Garther.Forum.Database.Repositories.Interfaces;

public interface IForumRepository
{
    Task<bool> ForumExistsAsync(Guid id, CancellationToken token);
    Task CreateForumAsync(Entities.Forum forum, CancellationToken token);
    Task<Forum.Database.Entities.Forum> GetForumByIdAsync(Guid id, CancellationToken token);
    Task<IEnumerable<IEnumerable<Entities.Forum>>> GetForumByIdAsync(Guid id, int count, int skip, CancellationToken token);
}