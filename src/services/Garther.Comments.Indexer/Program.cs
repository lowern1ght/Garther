using Garther.Comments.Indexer;

var builder = WebApplication.CreateBuilder(args);

var indexerSettings = builder.Configuration
    .GetValue<string>(nameof(IndexClientSettings.ElasticIp));

var app = builder.Build();

app.Run();