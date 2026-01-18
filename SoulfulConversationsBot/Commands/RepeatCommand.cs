using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SoulfulConversationsBot.Commands
{
	/// <summary>
	/// Repeat command.
	/// </summary>
	public class RepeatCommand : BaseCommandModule
	{
		#region Public Methods

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="data">Data.</param>
		[Command("repeat")]
		public async Task ExecuteAsync(CommandContext context, params string[] data)
		{
			await context.Channel.SendMessageAsync(string.Join(" ", data));
		}

		#endregion
	}
}
