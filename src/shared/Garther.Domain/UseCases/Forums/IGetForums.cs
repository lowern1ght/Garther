using Garther.Domain.Models;

namespace Garther.Domain.UseCases.Forums;

public interface IGetForums
{
    Task<IEnumerable<Forum>> ExecuteAsync(CancellationToken token);
}