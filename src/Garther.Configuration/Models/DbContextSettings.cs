using Microsoft.EntityFrameworkCore;

namespace Garther.Configuration.Models;

public class DbContextSettings<TDbContext>
    where TDbContext : DbContext
{
    public string? Host { get; set; }
    public int?    Port { get; set; }
    public string? Database { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}