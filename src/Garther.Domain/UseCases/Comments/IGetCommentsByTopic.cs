using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Comments;

public interface IGetCommentsByTopic
{
    Task<IEnumerable<Comment>> ExecuteAsync(Guid topicId, string text);
}