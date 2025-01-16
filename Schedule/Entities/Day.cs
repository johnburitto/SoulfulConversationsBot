using System.Globalization;

namespace Schedule.Entities
{
    public class Day : IFancy
    { 
        public DateTime Date { get; set; }
        public List<Hour>? Hours { get; set; }

        public string Fancy()
        {
            return $"{Date}\n{string.Join("\n", Hours!.Select(hour => hour.Fancy()))}";
        }

        public string EmojiDay(bool isMobile = false)
        {
            return string.Join(isMobile ? " " : "", Date.Date.ToString("dd", CultureInfo.InvariantCulture)
                                                             .Select(EmojiDay));
        }

        public string EmojiDay(char number) => number switch
        {
            '1' => "1️⃣",
            '2' => "2️⃣",
            '3' => "3️⃣",
            '4' => "4️⃣",
            '5' => "5️⃣",
            '6' => "6️⃣",
            '7' => "7️⃣",
            '8' => "8️⃣",
            '9' => "9️⃣",
            _ => "0️⃣"
        };
    }
}
