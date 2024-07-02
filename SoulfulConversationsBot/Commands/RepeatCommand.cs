using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SoulfulConversationsBot.Commands
{
    public class RepeatCommand : BaseCommandModule
    {
        [Command("repeat")]
        public async Task ExecuteAsync(CommandContext ctx, params string[] data)
        {
            await ctx.Channel.SendMessageAsync(string.Join(" ", data));
        }
    }
}
