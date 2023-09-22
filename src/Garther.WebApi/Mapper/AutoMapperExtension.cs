using AutoMapper;
using Garther.Configuration.Models;
using Garther.Forum.Database;
using Npgsql;

namespace Garther.WebApi.Mapper;

public static class AutoMapperExtension 
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddAutoMapper(config =>
        {
            config.CreateMap<NpgsqlConnectionStringBuilder, DbContextSettings<ForumDbContext>>()
                .ReverseMap();
        });
    }
}