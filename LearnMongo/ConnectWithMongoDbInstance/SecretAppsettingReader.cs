using Microsoft.Extensions.Configuration;

namespace ConnectWithMongoDbInstance
{
    public class SecretAppsettingReader
    {
        public IConfigurationSection ReadSection(string sectionName)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>(optional: true);
            var configurationRoot = builder.Build();

            return configurationRoot.GetSection(sectionName);
        }
    }
}
