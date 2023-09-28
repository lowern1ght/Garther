using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Indexing;

public interface ISearchCommentByText
{
    Task<Comment?> ExecuteAsync(string text, CancellationToken token);
}