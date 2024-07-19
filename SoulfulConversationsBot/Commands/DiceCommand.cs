using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SoulfulConversationsBot.Configuration;

namespace SoulfulConversationsBot.Commands
{
    public class DiceCommand : BaseCommandModule
    {
        private readonly Random _rng = new Random();

        [Command("dice")]
        public async Task ExecuteAsync(CommandContext context)
        {
            var result = string.Format("DiceFaces:Dice{0}", _rng.Next(1, 7));
            var embedMessage = new DiscordEmbedBuilder().WithImageUrl(ConfigurationManager.GetValue<string>(result));

            await context.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}
