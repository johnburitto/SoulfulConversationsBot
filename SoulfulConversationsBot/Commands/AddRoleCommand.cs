using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;

using SoulfulConversationsBot.Utils;

namespace SoulfulConversationsBot.Commands
{
	/// <summary>
	/// Add role command.
	/// </summary>
	public class AddRoleCommand : BaseCommandModule
	{
		#region Private Fields

		/// <summary>
		/// Json dictionary manager.
		/// </summary>
		private readonly JsonDictionaryManager<string, DiscordRole> _manager = new("roles.json");

		#endregion

		#region Public Methods

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="registerRole">Indicates whether register role or not.</param>
		/// <param name="roleNames">Role names.</param>
		[Command("addrole")]
		public async Task ExecuteAsync(CommandContext context, bool registerRole = true, params string[] roleNames)
		{
			var interactivity = context.Client.GetInteractivity();

			if (!registerRole)
			{
				var role = context.Guild.Roles.Where(_ => _.Value.Name == string.Join(" ", roleNames)).Select(_ => _.Value).FirstOrDefault();
				var embedMessage = new DiscordEmbedBuilder()
				{
					Title = "Відреагуйте емодзі, яке відповідає ролі",
					Color = DiscordColor.Blue
				};
				var message = await context.Channel.SendMessageAsync(embed: embedMessage);
				var emoji = (await interactivity.WaitForReactionAsync(_ => _.Message.Id == message.Id)).Result.Emoji;

				if (emoji.Name != string.Empty && role != null)
				{
					_manager.AddValue(emoji.Name, role);
					_manager.SaveChanges();
				}
			}
		}

		#endregion
	}
}
