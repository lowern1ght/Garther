using Garther.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garther.Domain;

public class ForumDbContext : DbContext
{
    public ForumDbContext(DbContextOptions<ForumDbContext> options)
        : base(options) { }

    public DbSet<User> User { get; set; } = null!;
    public DbSet<Forum> Forums { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
}