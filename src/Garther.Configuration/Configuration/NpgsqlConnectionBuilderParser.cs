using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Garther.Configuration.Configuration;

public static class NpgsqlConnectionBuilderParser
{
    public static NpgsqlConnectionStringBuilder GetConnectionStringBuilder<TDbContext>(this IConfiguration configuration)
        where TDbContext : DbContext
    {
        return configuration.GetSection(typeof(TDbContext).Name)
            .Get<NpgsqlConnectionStringBuilder>() ?? throw new InvalidOperationException("Failed parse to string builder");
    }
}