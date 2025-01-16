using Schedule.Entities;

namespace SoulfulConversationsBot.Extensions
{
    public static class ListExtensions
    {
        public static string ToDaysString(this List<Day> days, string start, bool isMobile)
        {
            var dayString = string.Empty;

            if (isMobile)
            {
                var dividedNumbers = days.Select(day => day.EmojiDay(isMobile))
                                         .Select(day => day.Split(" "));
                var firstRow = string.Join(" ", dividedNumbers.Select(number => number.First()));
                var lastRow = string.Join(" ", dividedNumbers.Select(number => number.Last()));

                dayString = $"{start}{firstRow}\n{start}{lastRow}";
            }
            else
            {
                dayString = $"{start}{string.Join(" ", days.Select(day => day.EmojiDay()))}";
            }

            return dayString;
        }
    }
}
