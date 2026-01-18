using System.Data;
using System.Reflection;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity.Extensions;

namespace SoulfulConversationsBot.Bot
{
	/// <summary>
	/// Discrod bot.
	/// </summary>
	public class DiscordBot
	{
		#region Private Fields

		/// <summary>
		/// Discord client.
		/// </summary>
		private DiscordClient? _bot;
		
		/// <summary>
		/// Commands.
		/// </summary>
		private CommandsNextExtension? _commands;

		#endregion

		#region Public Methods

		/// <summary>
		/// Configures the bot.
		/// </summary>
		/// <param name="configuration">Bot configuration.</param>
		public void Configure(DiscordConfiguration? configuration)
		{
			_bot = new DiscordClient(configuration);

			_bot.UseInteractivity(new()
			{
				Timeout = TimeSpan.FromMinutes(2)
			});
		}

		/// <summary>
		/// Configures the commands.
		/// </summary>
		/// <param name="configuration">Commands configuration</param>
		public void ConfigureCommands(CommandsNextConfiguration configuration)
		{
			_commands = _bot?.UseCommandsNext(configuration);

			List<Type> commandList = GetCommands();

			foreach (Type command in commandList)
			{
				_commands?.RegisterCommands(command);
			}
		}

		/// <summary>
		/// Starts the bot.
		/// </summary>
		public async Task Start()
			=> await _bot!.ConnectAsync();

		#endregion

		#region Private Methods

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static List<Type> GetCommands()
			=> [.. Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => String.Equals(t.Namespace, "SoulfulConversationsBot.Commands", StringComparison.Ordinal) && t.Name.EndsWith("Command"))];

		#endregion
	}
}
