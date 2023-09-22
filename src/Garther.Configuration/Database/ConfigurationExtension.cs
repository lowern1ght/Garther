using AutoMapper;
using Garther.Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Garther.Configuration.Database;

public static class ConfigurationExtension
{
    private static readonly IMapper Mapper = new MapperConfiguration(config
            => config.CreateMap<DbContextSettings<DbContext>, NpgsqlConnectionStringBuilder>())
        .CreateMapper();
    
    internal static DbContextSettings<TDbContext> GetDbContextSettings<TDbContext>(this ConfigurationManager configuration) 
        where TDbContext : DbContext
    {
        return GetDbContextSettings<TDbContext>(configuration, typeof(TDbContext).Name, 
            DefaultParserConfiguration.DefaultFileName);
    }

    internal static DbContextSettings<TDbContext> GetDbContextSettings<TDbContext>(this ConfigurationManager configuration,
        string dbContextName, string configFileName)
            where TDbContext : DbContext
    {
        configuration.AddJsonFile(configFileName);
        return  configuration.GetSection(dbContextName)
                    .Get<DbContextSettings<TDbContext>>() ?? 
                throw new InvalidOperationException($"Error with parse setting {dbContextName}");
    }

    internal static NpgsqlConnectionStringBuilder GetConnectionStringFromDbSettings<TDbContext>(this ConfigurationManager configuration)
        where TDbContext : DbContext
    {
        return Mapper.Map<NpgsqlConnectionStringBuilder>(GetDbContextSettings<TDbContext>(configuration));
    }
}