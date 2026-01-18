using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

using SoulfulConversationsBot.Dto;
using SoulfulConversationsBot.Enums;
using SoulfulConversationsBot.Configuration;

namespace SoulfulConversationsBot.Commands
{
	/// <summary>
	/// Coin flip command.
	/// </summary>
	public class CoinFlipCommand : BaseCommandModule
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
		/// Creates a new instance of <see cref="CoinFlipCommand"/> class.
		/// </summary>
		public CoinFlipCommand()
		{
			_imagesDto = ConfigurationManager.GetOptions<ImagesDto>()!.Value;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="context">Context.</param>
		[Command("coinflip")]
		public async Task ExecuteAsync(CommandContext context)
		{
			var embedMessage = new DiscordEmbedBuilder().WithTitle("Чарівна монетка показала")
														.WithImageUrl(_rng.Next(2) == 0 ? _imagesDto[Image.CoinTail]
																						: _imagesDto[Image.CoinHead]);

			await context.Channel.SendMessageAsync(embed: embedMessage);
		}

		#endregion
	}
}
