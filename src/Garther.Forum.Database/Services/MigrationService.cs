using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Garther.Forum.Database.Services;

public class MigrationService : IMigrationService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task MigrateAsync<TDbContext>()
        where TDbContext : DbContext
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}