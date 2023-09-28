using System.Reflection;
using Garther.Configuration.Configuration;
using Garther.Shared.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Garther.Forum.Database.DI;

public static class ServiceCollectionExtension
{
    private static readonly string RepositoryTypeName = "Repository";

    public static IServiceCollection AddForumStorage(this IServiceCollection serviceCollection,
        IConfiguration? configuration = null)
    {
        var stringBuilder = configuration?.GetConnectionStringBuilder<ForumDbContext>();

        serviceCollection.AddDbContext<ForumDbContext>(builder
            => builder.UseNpgsql(stringBuilder?.ConnectionString ?? string.Empty));

        return serviceCollection;
    }

    public static IServiceCollection AddForumsRepository(this IServiceCollection serviceCollection)
    {
        var assemblyTypes = Assembly.GetAssembly(typeof(ForumDbContext))
            ?.GetTypes();

        if (assemblyTypes is null) throw new InvalidOperationException(nameof(Database) + " assembly not loaded");

        foreach (var type in assemblyTypes)
            if (type.GetInterfaces().Any(inter => inter.Name.Contains(RepositoryTypeName)))
                serviceCollection.AddScoped(type.GetInterfaceByName(RepositoryTypeName), type);

        return serviceCollection;
    }
}