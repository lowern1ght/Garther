using Microsoft.Extensions.DependencyInjection;

namespace Garther.Domain.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomainUseCases(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}