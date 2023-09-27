using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Indexing;

public interface ICreateIndexComment
{
    Task ExecuteAsync(Forum forum, Topic topic, Comment comment, CancellationToken token);
}