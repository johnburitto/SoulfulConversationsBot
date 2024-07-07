// MTI1NzYwODE3NTU3OTAzNzc2Ng.GBrGmt.4sON2rmFpOE7VOdEGJ41YvTF2IoN-OqsVc4KVE
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Configuration;
using SoulfulConversationsBot.Commands;
using SoulfulConversationsBot.Configuration;

// TODO: Окремий клас для конфігруації бота та команд. Зробити конфігуратор
var configuration = new DiscordConfiguration()
{
    Intents = DiscordIntents.All,
    // NOTE: do not upload the token to Git for the security sake).
    // You can keep it in a file that is listed in .gitignore instead
    Token = "MTI1NzYwODE3NTU3OTAzNzc2Ng.GBrGmt.4sON2rmFpOE7VOdEGJ41YvTF2IoN-OqsVc4KVE",
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

await client.ConnectAsync();
await Task.Delay(-1);

static Task ClientReadyAsync(DiscordClient sender, ReadyEventArgs args)
{
    return Task.CompletedTask;
}

//SoulfulConversationsBot.Configuration.ConfigurationManager.ConfigureBot();