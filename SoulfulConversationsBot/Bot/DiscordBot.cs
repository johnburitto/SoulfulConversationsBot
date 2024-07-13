using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity.Extensions;
using System.Data;
using System.Reflection;

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

            List<Type> commandList = GetCommands();

            foreach (Type command in commandList)
            {
                _commands?.RegisterCommands(command);
            }

        }

        public async Task Start()
        {
            await _bot!.ConnectAsync();
        }

        private List<Type> GetCommands()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => String.Equals(t.Namespace, "SoulfulConversationsBot.Commands", StringComparison.Ordinal) && !t.IsNested)
                .ToList();
        }
    }
}
