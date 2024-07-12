using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity.Extensions;
using SoulfulConversationsBot.Commands;

namespace SoulfulConversationsBot.Bot
{
    public class DiscordBot
    {
        private DiscordClient? _bot;
        private CommandsNextExtension? _commands;

        public void Configure(DiscordConfiguration? configuration)
        {
            _bot = new DiscordClient(configuration);

            _bot.UseInteractivity(new()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });
        }

        public void ConfigureCommands(CommandsNextConfiguration? configuration)
        {
            _commands = _bot?.UseCommandsNext(configuration ?? throw new ArgumentNullException(nameof(configuration)));

            // TODO: This through Assembly
            _commands?.RegisterCommands<RepeatCommand>();
            _commands?.RegisterCommands<AddRoleCommand>();
            _commands?.RegisterCommands<ToggleRoleCommand>();
        }

        public async Task Start()
        {
            await _bot!.ConnectAsync();
        }
    }
}
