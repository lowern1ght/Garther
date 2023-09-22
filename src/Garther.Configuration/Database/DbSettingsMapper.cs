using AutoMapper;
using Garther.Configuration.Models;
using Garther.Forum.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Garther.Configuration.Database;

public static class DbSettingsMapper
{
    private static readonly IMapper Mapper = new MapperConfiguration(expression => expression.CreateMap<NpgsqlConnectionStringBuilder, DbContextSettings<ForumDbContext>>()
            .ReverseMap())
        .CreateMapper(); 
    
    public static NpgsqlConnectionStringBuilder MappedDbContextSettings<TDbContext>(
        DbContextSettings<TDbContext> contextSettings)
        where TDbContext : DbContext
    {
        return Mapper.Map<NpgsqlConnectionStringBuilder>(contextSettings);
    }
}