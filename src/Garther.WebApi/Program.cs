using System.Globalization;
using Garther.Configuration.Configuration;
using Garther.Configuration.Logger;
using Garther.Forum.Database;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Logging.ClearProviders()
    .AddSerilog(LogEventLevel.Debug);

var stringBuilder = builder.Configuration.GetConnectionStringBuilder<ForumDbContext>();

builder.Services.AddDbContext<ForumDbContext>(optionsBuilder 
    => optionsBuilder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
        .UseNpgsql(stringBuilder.ConnectionString));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();