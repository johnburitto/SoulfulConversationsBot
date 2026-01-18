using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Configuration
{
	/// <summary>
	/// Configuration manager .
	/// </summary>
	public static class ConfigurationManager
	{
		#region Private Fields

		/// <summary>
		/// Configuratiom.
		/// </summary>
		private static IConfiguration? _configuration;

		/// <summary>
		/// Service collection.
		/// </summary>
		private static IServiceCollection? _serviceCollection;

		/// <summary>
		/// Service provider.
		/// </summary>
		private static IServiceProvider? _serviceProvider;

		/// <summary>
		/// Lock object.
		/// </summary>
		private static readonly Lock _lock = new();

		#endregion

		#region Public Properties

		/// <summary>
		/// Configuration.
		/// </summary>
		public static IConfiguration Configuration => GetConfiguration();

		/// <summary>
		/// Service collection.
		/// </summary>
		public static IServiceCollection ServiceCollection => GetServiceCollection();

		/// <summary>
		/// Service provider.
		/// </summary>
		public static IServiceProvider ServiceProvider => GetServiceProvider();

		#endregion

		#region Public Methods

		/// <summary>
		/// Configures services.
		/// </summary>
		public static void Configure()
		{
			ServiceCollection.Configure<BotConfigurationDto>(options => Configuration.GetSection("BotConfigurationDto").Bind(options));
			ServiceCollection.Configure<CommandsConfiguration>(options => Configuration.GetSection("CommandsConfiguration").Bind(options));
			ServiceCollection.Configure<ImagesDto>(options => Configuration.GetSection("ImagesDto").Bind(options));
		}

		/// <summary>
		/// Gets value from configuration.
		/// </summary>
		/// <typeparam name="T">Value type.</typeparam>
		/// <param name="section">Section name.</param>
		/// <returns>Value.</returns>
		public static T? GetValue<T>(string section)
			=> Configuration.GetValue<T>(section);

		/// <summary>
		/// Get options.
		/// </summary>
		/// <typeparam name="T">Options type.</typeparam>
		/// <returns>Options.</returns>
		public static IOptions<T>? GetOptions<T>() where T : class
			=> ServiceProvider.GetService<IOptions<T>>();

		#endregion

		#region Private Methods

		/// <summary>
		/// Creates configuration.
		/// </summary>
		/// <returns>Configuration.</returns>
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

		/// <summary>
		/// Creates service collection.
		/// </summary>
		/// <returns>Service collection.</returns>
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

		/// <summary>
		/// Creates service provider.
		/// </summary>
		/// <returns>Service provider.</returns>
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

		#endregion
	}
}
