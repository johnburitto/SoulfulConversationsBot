using DSharpPlus;
using DSharpPlus.Entities;

namespace SoulfulConversationsBot.Extensions
{
	/// <summary>
	/// Dictionary extensions.
	/// </summary>
	public static class DictionaryExtensions
	{
		#region Public Methods

		/// <summary>
		/// Converts a dictionary of roles to a list of emojis.
		/// </summary>
		/// <param name="roles">Roles.</param>
		/// <param name="client">Discord client.</param>
		/// <returns>List of emojis.</returns>
		public static List<DiscordEmoji> ToEmojis(this Dictionary<string, DiscordRole> roles, DiscordClient client)
			=> [.. roles.Select(_ => DiscordEmoji.FromName(client, $":{_.Key}:"))];

		#endregion
	}
}