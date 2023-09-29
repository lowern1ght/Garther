using System.Collections;
using Garther.Forum.Database.Entities;

namespace Garther.Forum.Database.Repositories.Interfaces;

public interface ICommentRepository : IAddEntity<Comment>
{
    Task<Comment> GetCommentById(Guid id, CancellationToken token);
    Task<IEnumerable<Comment>> GetCommentsByUser(Guid userId, CancellationToken token);
    Task<IEnumerable<Comment>> GetCommentsByTopic(Guid topicId, CancellationToken token);
}