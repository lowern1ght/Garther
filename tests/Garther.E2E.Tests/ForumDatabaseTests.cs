using System.Reflection;
using Garther.Forum.Database;
using Garther.Forum.Database.DI;
using Garther.Shared.Extension;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace Garther.E2E.Tests;

public class ForumDatabaseTests
{
    [Fact]
    public void RepositoriesExistsInAssembly()
    {
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddForumStorage()
            .AddForumsRepository();

        var assertsTypes = GetAssertTypes();
        
        Assert.True(false);
    }

    private static readonly string RepositoryName = "Repository";
    
    private static IList<KeyValuePair<Type, Type>> GetAssertTypes()
    {
        var types = Assembly.GetAssembly(typeof(ForumDbContext))
            ?.GetTypes();

        if (types is null)
        {
            throw new ArgumentNullException(nameof(types));
        }
        
        var result = new List<KeyValuePair<Type, Type>>();
        
        foreach (var type in types)
        {
            if (type is { IsClass: true, Name: var name } && name.Contains(RepositoryName) && 
                type.GetInterfaceByName(RepositoryName) is {} inter)
            {
                result.Add(new(type, inter));
            }
        }

        return result;
    }
}