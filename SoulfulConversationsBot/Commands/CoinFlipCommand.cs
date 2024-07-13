using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SoulfulConversationsBot.Commands
{
    public class CoinFlipCommand : BaseCommandModule
    {
        private readonly Random _rng = new Random();

        [Command("coinflip")]
        public async Task ExecuteAsync(CommandContext context)
        {
            string result;
            if (_rng.Next(2) == 0)
            {
                result = "**орел**";
            }
            else
            {
                result = "**решка**";
            }
            await context.Channel.SendMessageAsync("Результат: " + result);
        }
    }
}
