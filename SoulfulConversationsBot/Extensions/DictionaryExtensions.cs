using DSharpPlus;
using DSharpPlus.Entities;

namespace SoulfulConversationsBot.Extensions
{
    public static class DictionaryExtensions
    {
        public static List<DiscordActionRowComponent> ToButtons(this IReadOnlyDictionary<ulong, DiscordRole> roles)
        {
            return roles.Select((_, index) => new { Index = index, Data = new DiscordButtonComponent(ButtonStyle.Primary, $"{_.Value.Name}_id".Replace(" ", "_").ToLower(), _.Value.Name) })
                        .GroupBy(_ => _.Index / 5)
                        .Select(_ => new DiscordActionRowComponent(_.Select(_ => _.Data)))
                        .ToList();
        }
    }
}
