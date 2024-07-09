using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using SoulfulConversationsBot.Utils;

namespace SoulfulConversationsBot.Commands
{
    public class AddRoleCommand : BaseCommandModule
    {
        private readonly JsonDictionaryManager<string, DiscordRole> _manager = new JsonDictionaryManager<string, DiscordRole>("roles.json");

        [Command("addrole")]
        public async Task ExecuteAsync(CommandContext context, bool registerRole = true, params string[] roleName)
        {
            var interactivity = context.Client.GetInteractivity();

            if (!registerRole)
            {
                var role = context.Guild.Roles.Where(_ => _.Value.Name == string.Join(" ", roleName)).Select(_ => _.Value).FirstOrDefault();
                var embedMessage = new DiscordEmbedBuilder()
                {
                    Title = "Відреагуйте емодзі, яке відповідає ролі",
                    Color = DiscordColor.Blue
                };
                var message = await context.Channel.SendMessageAsync(embed: embedMessage);
                var emoji = (await interactivity.WaitForReactionAsync(_ => _.Message.Id == message.Id)).Result.Emoji;

                if (emoji.Name != string.Empty && role != null)
                {
                    _manager.AddValue(emoji.Name, role);
                    _manager.SaveChanges();
                }
            }
        }
    }
}
