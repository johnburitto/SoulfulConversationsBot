using DSharpPlus;
using DSharpPlus.Entities;

namespace SoulfulConversationsBot.Extensions
{
    public static class DictionaryExtensions
    {
        public static List<DiscordEmoji> ToEmojis(this Dictionary<string, DiscordRole> roles, DiscordClient client)
        {
            return roles.Select(_ => DiscordEmoji.FromName(client, $":{_.Key}:"))
                        .ToList();
        }
    }
}
