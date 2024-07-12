using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Configuration
{
    public static class ConfigurationManager
    {
        private static IConfiguration? _configuration;
        private static IServiceCollection? _serviceCollection;
        private static IServiceProvider? _serviceProvider;
        private static object _lock = new object();

        public static IConfiguration Configuration => GetConfiguration();
        public static IServiceCollection ServiceCollection => GetServiceCollection();
        public static IServiceProvider ServiceProvider => GetServiceProvider();

        private static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                lock (_lock)
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .Build();
                }
            }

            return _configuration;
        }

        private static IServiceCollection GetServiceCollection()
        {
            if (_serviceCollection == null)
            {
                lock (_lock)
                {
                    _serviceCollection = new ServiceCollection();
                }
            }

            return _serviceCollection;
        }

        private static IServiceProvider GetServiceProvider()
        {
            if (_serviceProvider == null)
            {
                lock (_lock)
                {
                    _serviceProvider = ServiceCollection.BuildServiceProvider();
                }
            }

            return _serviceProvider;
        }

        public static void Configure()
        {
            ServiceCollection.Configure<BotConfigurationDto>(options => Configuration.GetSection("BotConfigurationDto").Bind(options));
            ServiceCollection.Configure<CommandsConfiguration>(options => Configuration.GetSection("CommandsConfiguration").Bind(options));
        }

        public static IOptions<T>? GetOptions<T>() where T : class
        {
            return ServiceProvider.GetService<IOptions<T>>();
        }
    }
}
