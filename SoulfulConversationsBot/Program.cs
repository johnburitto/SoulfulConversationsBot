using SoulfulConversationsBot.Bot;

var builder = new BotBuilder();

builder.ConfigureSystem()
       .ConfigureAutoMapper();

builder.ConfigureBot()
       .ConfigureCommands();

var bot = builder.Build();

bot?.Start();
await Task.Delay(-1);
