namespace Garther.Forum.Database.Repositories.Interfaces;

public interface IAddEntity<in TEntity>
{
    Task AddEntity(TEntity entity, CancellationToken token);
}