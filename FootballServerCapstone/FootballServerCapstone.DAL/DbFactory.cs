using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FootballServerCapstone.DAL
{
    public enum FactoryMode
    {
        TEST,
        PROD
    }
    public class DbFactory
    {
        private readonly IConfigurationRoot _Config;
        private readonly FactoryMode _Mode;

        //Default is Test
        public DbFactory(IConfigurationRoot config, FactoryMode mode = FactoryMode.TEST)
        {
            _Config = config;
            _Mode = mode;
        }
        public AppDbContext GetDbContext()
        {
            string environment = _Mode == FactoryMode.TEST ? "Test" : "Prod";
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(_Config[$"ConnectionStrings:{environment}"])
                .Options;
            return new AppDbContext(options);
        }
    }
}
