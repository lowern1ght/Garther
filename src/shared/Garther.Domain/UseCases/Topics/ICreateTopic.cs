using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Topics;

public interface ICreateTopic
{
    Task<Topic> ExecuteAsync(Guid id, string title, Guid userId, CancellationToken token);
}