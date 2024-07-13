using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SoulfulConversationsBot.Commands
{
    public class CoinFlip : BaseCommandModule
    {
        private readonly Random _rng = new Random();
        [Command("coinflip")]
        public async Task ExecuteAsync(CommandContext context)
        {
            string result;
            if (_rng.Next(2) == 0)
            {
                result = "Орел";
            }
            else
            {
                result = "Решка";
            }
            await context.Channel.SendMessageAsync("Результат: " + result);
        }
    }
}
