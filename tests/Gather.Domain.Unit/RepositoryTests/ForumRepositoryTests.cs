using Garther.Forum.Database;
using Garther.Forum.Database.DI;
using Garther.Forum.Database.Entities;
using Garther.Forum.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gather.Domain.Unit.RepositoryTests;

public class ForumRepositoryTests
{
    private readonly IServiceProvider _serviceProvider;
    
    public ForumRepositoryTests()
    {
        var serviceCollection = new ServiceCollection()
            .AddDbContext<ForumDbContext>(builder 
            //Test is bad, in memory base not implementation transaction
                => builder.UseInMemoryDatabase("forum_test"))
            .AddForumsRepository();
        
        serviceCollection.AddAutoMapper(expression =>
        {
            expression.CreateMap<Forum, Garther.Domain.Models.Forum>()
                .ReverseMap();
        });
        
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public async Task CreateNewForumShould()
    {
        var exception = await Record.ExceptionAsync(async () => 
            await _serviceProvider.GetRequiredService<IForumRepository>()
                .CreateForumAsync(
                    new() { Id = Guid.Parse("6DD564CA-C057-4E3E-8FAA-4ED53DED1F29"), Title = "It Books", Topics = null },
                    new CancellationTokenSource().Token));
        
        Assert.Null(exception);
    }
}