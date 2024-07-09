// MTI1NzYwODE3NTU3OTAzNzc2Ng.GBrGmt.4sON2rmFpOE7VOdEGJ41YvTF2IoN-OqsVc4KVE
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Configuration;
using SoulfulConversationsBot.Commands;
using SoulfulConversationsBot.Configuration;

// TODO: Окремий клас для конфігруації бота та команд. Зробити конфігуратор

var discordClient = SoulfulConversationsBot.Configuration.ConfigurationManager.ConfigureDiscordClient();

await discordClient.ConnectAsync();
await Task.Delay(-1);

