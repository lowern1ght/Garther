using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Forums;

public interface ICreateForum
{
    Task<Forum> ExecuteAsync(Guid id, string title, Guid userId, CancellationToken token);
}