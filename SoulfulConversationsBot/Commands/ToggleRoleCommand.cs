using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using SoulfulConversationsBot.Extensions;
using SoulfulConversationsBot.Utils;

namespace SoulfulConversationsBot.Commands
{
    public class ToggleRoleCommand : BaseCommandModule
    {
        private readonly JsonDictionaryManager<string, DiscordRole> _manager = new JsonDictionaryManager<string, DiscordRole>("roles.json");

        [Command("roles")]
        public async Task ExecuteAsync(CommandContext context)
        {
            var emojis = _manager.Data.ToEmojis(context.Client);
            var embedMessage = new DiscordEmbedBuilder()
            {
                Title = "Оберіть роль",
                Description = "Для вибору ролі неохідно на тиснути на відповідний емодзі знизу",
                Color = DiscordColor.Blue
            };
            var message = await context.Channel.SendMessageAsync(embed: embedMessage);

            foreach (var _ in emojis)
            {
                await message.CreateReactionAsync(_);
            }

            var interactivity = context.Client.GetInteractivity();
            var reply = await interactivity.WaitForReactionAsync(_ => _.Message.Id == message.Id);
            _manager.Data.TryGetValue(reply.Result.Emoji.Name, out var role);

            if (context.Member!.Roles.Contains(role))
            {
                await (reply.Result.User as DiscordMember)!.RevokeRoleAsync(role);

                var respone = new DiscordEmbedBuilder()
                {
                    Title = $"⚠️ У користувача {reply.Result.User.Username} було забрано роль {role?.Name}",
                    Color = DiscordColor.Red
                };

                await context.Channel.SendMessageAsync(respone);
                await context.Channel.DeleteMessageAsync(message);
            }
            else
            {
                await (reply.Result.User as DiscordMember)!.GrantRoleAsync(role);

                var respone = new DiscordEmbedBuilder()
                {
                    Title = $"✅ Користувачу {reply.Result.User.Username} було надано роль {role?.Name}",
                    Color = DiscordColor.Green
                };

                await context.Channel.SendMessageAsync(respone);
                await context.Channel.DeleteMessageAsync(message);
            }
        }
    }
}
