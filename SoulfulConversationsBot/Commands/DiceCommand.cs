using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SoulfulConversationsBot.Configuration;
using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Commands
{
    public class DiceCommand : BaseCommandModule
    {
        private readonly Random _rng = new Random();
        private ImagesDto _imagesDto;

        public DiceCommand()
        {
            _imagesDto = ConfigurationManager.GetOptions<ImagesDto>()!.Value;
        }

        [Command("dice")]
        public async Task ExecuteAsync(CommandContext context)
        {
            var embedMessage = new DiscordEmbedBuilder().WithImageUrl(_imagesDto[(Image)_rng.Next(1, 7)]);

            await context.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}
