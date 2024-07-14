using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SoulfulConversationsBot.Configuration;

namespace SoulfulConversationsBot.Commands
{
    public class CoinFlipCommand : BaseCommandModule
    {
        private readonly Random _rng = new Random();

        [Command("coinflip")]
        public async Task ExecuteAsync(CommandContext context)
        {
            // NEW
            var embedMessage = new DiscordEmbedBuilder().WithTitle("Чарівна монетка показала")
                                                        .WithImageUrl(_rng.Next(2) == 0 ? ConfigurationManager.GetValue<string>("CoinTail")
                                                                                        : ConfigurationManager.GetValue<string>("CoinHead"));

            await context.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}

// OLD
//string result;

//if (_rng.Next(2) == 0)
//{
//    result = "**орел**";
//}

//else
//{
//    result = "**решка**";
//}

//await context.Channel.SendMessageAsync("Результат: " + result);

// IMPROVED OLD
//await context.Channel.SendMessageAsync("Результат: " + (_rng.Next(2) == 0 ? "**орел**" : "**решка**"));
