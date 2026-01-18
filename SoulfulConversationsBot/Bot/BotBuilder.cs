using AutoMapper;

using DSharpPlus;
using DSharpPlus.CommandsNext;

using Microsoft.Extensions.Logging.Abstractions;

using SoulfulConversationsBot.Dto;
using SoulfulConversationsBot.Profiles;
using SoulfulConversationsBot.Configuration;

namespace SoulfulConversationsBot.Bot
{
	/// <summary>
	/// Bot builde.
	/// </summary>
	public class BotBuilder
	{
		#region Private Fields

		/// <summary>
		/// Dscord bot.
		/// </summary>
		private DiscordBot _bot;
		
		/// <summary>
		/// Mapper.
		/// </summary>
		private IMapper? _mapper;

		#endregion

		#region Constructor

		/// <summary>
		/// Creates a new instance of the <see cref="BotBuilder"/> class.
		/// </summary>
		public BotBuilder() 
		{ 
			_bot = new DiscordBot();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Configures the system.
		/// </summary>
		/// <returns>Bot builder.</returns>
		public BotBuilder ConfigureSystem()
		{
			ConfigurationManager.Configure();

			return this;
		}

		/// <summary>
		/// Configures AutoMapper.
		/// </summary>
		/// <returns>Bot builder.</returns>
		public BotBuilder ConfigureAutoMapper()
		{
			_mapper = new Mapper(new MapperConfiguration(configuration =>
			{
				configuration.AddProfile(new DiscordConfigurationProfile());
				configuration.AddProfile(new CommandsNextConfigurationProfile());
			}, new NullLoggerFactory()));

			return this;
		}

		/// <summary>
		/// Configures the bot.
		/// </summary>
		/// <returns>Bot builder.</returns>
		public BotBuilder ConfigureBot()
		{
			var configrationDto = ConfigurationManager.GetOptions<BotConfigurationDto>()?.Value;
			var configuration = _mapper?.Map<DiscordConfiguration>(configrationDto);

			_bot.Configure(configuration);

			return this;
		}

		/// <summary>
		/// Configures the commands.
		/// </summary>
		/// <returns>Bot builder.</returns>
		public BotBuilder ConfigureCommands()
		{
			var configrationDto = ConfigurationManager.GetOptions<CommandsConfiguration>()?.Value;
			var configuration = _mapper!.Map<CommandsNextConfiguration>(configrationDto);

			_bot.ConfigureCommands(configuration);

			return this;
		}

		/// <summary>
		/// Builds bot.
		/// </summary>
		/// <returns>Discord bot.</returns>
		public DiscordBot Build()
			=> _bot;

		#endregion
	}
}
