using DSharpPlus;

namespace SoulfulConversationsBot.Dto
{
	/// <summary>
	/// Bot configuration dto.
	/// </summary>
	public class BotConfigurationDto
	{
		/// <summary>
		/// Gets or sets intents.
		/// </summary>
		public DiscordIntents Intents { get; set; }

		/// <summary>
		/// Gets or sets token.
		/// </summary>
		public string? Token { get; set; }

		/// <summary>
		/// Gets or sets token type.
		/// </summary>
		public TokenType TokenType { get; set; }

		/// <summary>
		/// Gets or sets auto reconnect.
		/// </summary>
		public bool AutoReconnect { get; set; }
	}
}
