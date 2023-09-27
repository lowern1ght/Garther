using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Comments;

public interface ICreateMessage
{
    Task<Comment> ExecuteAsync(Guid id, Guid userId, Guid topicId, string message, CancellationToken token);
}