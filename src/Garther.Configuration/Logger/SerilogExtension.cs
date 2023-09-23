using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace Garther.Configuration.Logger;

public static class SerilogExtension
{
    public static ILoggingBuilder AddSerilog(this ILoggingBuilder loggingBuilder, LogEventLevel eventLevel)
    {
        return loggingBuilder.AddSerilog(CreateDefaultLogger(eventLevel));
    }

    private static ILogger CreateDefaultLogger(LogEventLevel eventLevel)
    {
        return new LoggerConfiguration()
            .MinimumLevel.Is(eventLevel)
            .WriteTo.Console()
            .CreateLogger();
    }
}