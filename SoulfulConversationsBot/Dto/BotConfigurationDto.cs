using DSharpPlus;

namespace SoulfulConversationsBot.Dto
{
    public class BotConfigurationDto
    {
        public DiscordIntents Intents { get; set; }
        public string? Token { get; set; }
        public TokenType TokenType { get; set; }
        public bool AutoReconnect { get; set; }
    }
}
