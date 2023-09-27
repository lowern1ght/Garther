using System.Reflection;
using Garther.Configuration.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Garther.Forum.Database.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddForumStorage(this IServiceCollection serviceCollection, IConfiguration? configuration = null)
    {
        var stringBuilder = configuration?.GetConnectionStringBuilder<ForumDbContext>();
        
        serviceCollection.AddDbContext<ForumDbContext>(builder 
            => builder.UseNpgsql(stringBuilder?.ConnectionString ?? string.Empty));
        
        return serviceCollection;
    }

    private static readonly string RepositoryTypeName = "Repository";
    
    public static IServiceCollection AddForumsRepository(this IServiceCollection serviceCollection)
    {
        var assemblyTypes = Assembly.GetAssembly(typeof(Garther.Forum.Database.ForumDbContext))
            ?.GetTypes();

        if (assemblyTypes is null)
        {
            throw new InvalidOperationException(nameof(Forum.Database) + " assembly not loaded");
        }
        
        foreach (var type in assemblyTypes)
        {
            if (type.GetInterfaces().Any(inter => inter.Name.Contains(RepositoryTypeName)))
            {
                serviceCollection.AddScoped(type.GetInterfaceByName(RepositoryTypeName), type);
            }
        }
        
        return serviceCollection;
    }

    private static Type GetInterfaceByName(this Type type, string interfaceName)
    {
        return type.GetInterfaces()
            .First(t => t.Name.Contains(interfaceName));
    }
}