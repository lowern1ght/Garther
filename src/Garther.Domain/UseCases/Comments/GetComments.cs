using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Comments;

public interface IGetComments
{
    Task<IEnumerable<Comment>> ExecuteAsync(Guid topicId, Guid userId, string text);
}