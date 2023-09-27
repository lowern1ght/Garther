using Garther.Forum.Database.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Garther.E2E.Tests;

public class ForumDatabaseTests
{
    [Fact]
    public void RepositoriesExistsInAssembly()
    {
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddForumStorage()
            .AddForumsRepository();

        Assert.True(false);
    }
}