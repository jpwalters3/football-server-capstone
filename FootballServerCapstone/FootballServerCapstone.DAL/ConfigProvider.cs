using Microsoft.Extensions.Configuration;

namespace FootballServerCapstone.DAL
{
    public class ConfigProvider
    {
        public IConfigurationRoot Config { get; private set; }
        public ConfigProvider()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<AppDbContext>();
            Config = builder.Build();
        }
    }
}
