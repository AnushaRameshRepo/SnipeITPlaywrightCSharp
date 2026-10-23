using Microsoft.Extensions.Configuration;
namespace SnipeIt.Config;

public static class appConfig
{
    private static readonly IConfiguration _config = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.local.json", optional: true)  // secrets, local only
        .AddEnvironmentVariables()                              // CI overrides
        .Build();
    public static string Username => _config["Credentials:Username"]
        ?? throw new InvalidOperationException("Credentials:Username is not configured.");
    public static string Password => _config["Credentials:Password"]
        ?? throw new InvalidOperationException("Credentials:Password is not configured.");

}