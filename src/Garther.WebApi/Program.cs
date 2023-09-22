using System.Globalization;
using Garther.Configuration.Database;
using Garther.Forum.Database;
using Garther.WebApi.Mapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders()
    .AddSerilog(logger);

builder.Services.AddAutoMapper();
builder.Services.AddControllers();

var contextSettings = builder.Configuration.GetDbContextSettings<ForumDbContext>(
    DefaultParserConfiguration.DefaultFileName);

var stringBuilder = DbSettingsMapper.MappedDbContextSettings(contextSettings);

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