using System.Text.Json.Serialization;

namespace Schedule.Entities
{
    public class Hour : IFancy
    {
        public string? HourString { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Availability Availability { get; set; }

        public string Fancy()
        {
            return $"{HourString}:\t{AvailabilityString()}";
        }

        public string AvailabilityString() => Availability switch
        {
            Availability.Free => "🟩",
            Availability.Maybe => "🟨",
            Availability.Busy => "🟥",
            _ => "❓"
        };
    }

    public enum Availability
    {
        Unknown,
        Free,
        Maybe,
        Busy
    }
}
