using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using SoulfulConversationsBot.Commands;

// TODO: Окремий клас для конфігруації бота та команд. Зробити конфігуратор
var configuration = new DiscordConfiguration()
{
    Intents = DiscordIntents.All | DiscordIntents.MessageContents, 
    Token = "MTI1NzYwODE3NTU3OTAzNzc2Ng.Gl0bfg.klZ2LhZmNY-Urhcc76M4YEzrrga76ntP_-kZm4",
    TokenType = TokenType.Bot,
    AutoReconnect = true
};
var commandsNextConfiguration = new CommandsNextConfiguration()
{
    StringPrefixes = ["!"],
    EnableMentionPrefix = true,
    EnableDms = true,
    EnableDefaultHelp = false
};
var client = new DiscordClient(configuration);
var commands = client.UseCommandsNext(commandsNextConfiguration);

client.UseInteractivity(new()
{
    Timeout = TimeSpan.FromMinutes(2)
});

client.Ready += ClientReadyAsync;
commands.RegisterCommands<RepeatCommand>();
commands.RegisterCommands<ToggleRoleCommand>();
commands.RegisterCommands<AddRoleCommand>();

await client.ConnectAsync();
await Task.Delay(-1);

static Task ClientReadyAsync(DiscordClient sender, ReadyEventArgs args)
{
    return Task.CompletedTask;
}
