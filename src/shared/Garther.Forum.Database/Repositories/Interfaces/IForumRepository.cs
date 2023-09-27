namespace Garther.Forum.Database.Repositories.Interfaces;

public interface IForumRepository
{
    Task<bool> ForumExists(Guid id, CancellationToken token);
    Task<Entities.Forum> CreateForumAsync(Guid id, string title, Guid userId, CancellationToken token);
    Task<IEnumerable<IEnumerable<Entities.Forum>>> GetForumsAsync(Guid id);
}