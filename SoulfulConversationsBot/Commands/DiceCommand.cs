using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

using SoulfulConversationsBot.Dto;
using SoulfulConversationsBot.Enums;
using SoulfulConversationsBot.Configuration;

namespace SoulfulConversationsBot.Commands
{
	/// <summary>
	/// Dice command.
	/// </summary>
	public class DiceCommand : BaseCommandModule
	{
		#region Private Fields

		/// <summary>
		/// Randomizer.
		/// </summary>
		private readonly Random _rng = new();

		/// <summary>
		/// Images dto.
		/// </summary>
		private readonly ImagesDto _imagesDto;

		#endregion

		#region Constructor

		/// <summary>
		/// Creates a new instance of the <see cref="DiceCommand"/> class.
		/// </summary>
		public DiceCommand()
		{
			_imagesDto = ConfigurationManager.GetOptions<ImagesDto>()!.Value;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="context">Context.</param>
		[Command("dice")]
		public async Task ExecuteAsync(CommandContext context)
		{
			var embedMessage = new DiscordEmbedBuilder().WithImageUrl(_imagesDto[(Image)_rng.Next(1, 7)]);

			await context.Channel.SendMessageAsync(embed: embedMessage);
		}

		#endregion
	}
}
