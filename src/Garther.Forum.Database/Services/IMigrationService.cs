using Microsoft.EntityFrameworkCore;

namespace Garther.Forum.Database.Services;

public interface IMigrationService
{
    Task MigrateAsync<TDbContext>()
        where TDbContext : DbContext;
}