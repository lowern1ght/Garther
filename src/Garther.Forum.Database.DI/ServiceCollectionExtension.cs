using Microsoft.Extensions.DependencyInjection;

namespace Garther.Forum.Database.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddForumStorage(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}