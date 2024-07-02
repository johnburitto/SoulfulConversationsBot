using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SoulfulConversationsBot.Extensions;

namespace SoulfulConversationsBot.Commands
{
    public class ToggleRoleCommand : BaseCommandModule
    {
        [Command("roles")]
        public async Task ExecuteAsync(CommandContext context)
        {
            var roles = context.Guild.Roles.ToButtons();
            var embedBuilder = new DiscordEmbedBuilder()
            {
                Title = "Оберіть роль",
                Color = DiscordColor.Blue,
                Description = "Оберіть роль, яку хочете отримати/позбутися"
            };
            var messageBuilder = new DiscordMessageBuilder();

            messageBuilder.AddEmbed(embedBuilder);
            messageBuilder.AddComponents(roles);

            await context.Channel.SendMessageAsync(messageBuilder);
        }
    }
}
