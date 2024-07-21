using System.Text.Json.Serialization;

namespace Schedule.Entities
{
    public class Hour
    {
        public string? HourString { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Availability Availability { get; set; }
    }

    public enum Availability
    {
        Unknown,
        Free,
        Maybe,
        Busy
    }
}
