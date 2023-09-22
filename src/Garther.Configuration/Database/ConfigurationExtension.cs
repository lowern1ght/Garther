using AutoMapper;
using Garther.Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Garther.Configuration.Database;

public static class ConfigurationExtension
{
    public static DbContextSettings<TDbContext> GetDbContextSettings<TDbContext>(this ConfigurationManager configuration, string configName) 
        where TDbContext : DbContext
    {
        if (configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            configName = configName.Replace(".", ".Development.");
        }
        
        configuration.AddJsonFile(configName, false, true);
        return configuration.GetSection(typeof(TDbContext).Name)
            .Get<DbContextSettings<TDbContext>>() ?? throw new ArgumentNullException(nameof(configName));
    }
}