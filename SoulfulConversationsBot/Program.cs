// MTI1NzYwODE3NTU3OTAzNzc2Ng.GBrGmt.4sON2rmFpOE7VOdEGJ41YvTF2IoN-OqsVc4KVE
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using SoulfulConversationsBot.Commands;

// TODO: Окремий клас для конфігруації бота та команд. Зробити конфігуратор
var configuration = new DiscordConfiguration()
{
    Intents = DiscordIntents.All, 
    Token = "MTI1NzYwODE3NTU3OTAzNzc2Ng.GBrGmt.4sON2rmFpOE7VOdEGJ41YvTF2IoN-OqsVc4KVE",
    TokenType = TokenType.Bot,
    AutoReconnect = true
};
var cammandsNextConfiguration = new CommandsNextConfiguration()
{
    StringPrefixes = ["!"],
    EnableMentionPrefix = true,
    EnableDms = true,
    EnableDefaultHelp = false
};
var client = new DiscordClient(configuration);
var commands = client.UseCommandsNext(cammandsNextConfiguration);

client.UseInteractivity(new()
{
    Timeout = TimeSpan.FromMinutes(2)
});

client.Ready += ClientReadyAsync;
commands.RegisterCommands<RepeatCommand>();
commands.RegisterCommands<ToggleRoleCommand>();

await client.ConnectAsync();
await Task.Delay(-1);

static Task ClientReadyAsync(DiscordClient sender, ReadyEventArgs args)
{
    return Task.CompletedTask;
}
