using Serilog.Events;
using System.Globalization;
using Garther.Configuration.Configuration;
using Garther.Configuration.Logger;
using Garther.Forum.Database;
using Garther.Forum.Database.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Logging.ClearProviders()
    .AddSerilog(LogEventLevel.Debug);

builder.Services.AddRouting(options 
    => options.LowercaseUrls = true);

var stringBuilder = builder.Configuration.GetConnectionStringBuilder<ForumDbContext>();

builder.Services.AddSingleton<IMigrationService, MigrationService>();

builder.Services.AddDbContext<ForumDbContext>(optionsBuilder 
    => optionsBuilder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
        .UseNpgsql(stringBuilder.ConnectionString));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var application = builder.Build();

application.Services.GetRequiredService<IMigrationService>()
    .MigrateAsync<ForumDbContext>();

if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseHttpsRedirection();

application.UseAuthorization();

application.MapControllers();

application.Run();