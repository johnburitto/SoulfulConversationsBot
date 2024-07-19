using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SoulfulConversationsBot.Configuration;
using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Commands
{
    public class CoinFlipCommand : BaseCommandModule
    {
        private readonly Random _rng = new Random();
        private ImagesDto _imagesDto;

        public CoinFlipCommand()
        {
            _imagesDto = ConfigurationManager.GetOptions<ImagesDto>()!.Value;
        }

        [Command("coinflip")]
        public async Task ExecuteAsync(CommandContext context)
        {
            var embedMessage = new DiscordEmbedBuilder().WithTitle("Чарівна монетка показала")
                                                        .WithImageUrl(_rng.Next(2) == 0 ? _imagesDto[Image.CoinTail]
                                                                                        : _imagesDto[Image.CoinHead]);

            await context.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}
