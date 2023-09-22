using Microsoft.Extensions.Configuration;

namespace Garther.Configuration.Database;

public static class DefaultParserConfiguration
{
    public static readonly string DefaultFileName = "dbcontext";
}

public static class FileDbSettingsExtension
{
    public static string GetDbSettingsFileName(this IConfiguration configuration, bool? isDevelopment = null)
    {
        if (isDevelopment is null)
        {
            var value = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");
            isDevelopment = !String.Equals(value, "Production", StringComparison.InvariantCultureIgnoreCase);
        }

        var fileName = DefaultParserConfiguration.DefaultFileName 
                       + ((bool)isDevelopment ? ".Development" : "") 
                       + "json";

        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
            throw new FileNotFoundException("file settings db context not found");

        return fileName;
    }
}