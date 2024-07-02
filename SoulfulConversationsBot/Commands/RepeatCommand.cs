using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SoulfulConversationsBot.Commands
{
    public class RepeatCommand : BaseCommandModule
    {
        [Command("repeat")]
        public async Task ExecuteAsync(CommandContext context, params string[] data)
        {
            await context.Channel.SendMessageAsync(string.Join(" ", data));
        }
    }
}
