using System.Text.Json.Serialization;

namespace Schedule.Entities
{
    public class PersonSchedule
    {
        public string? UserName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ScheduleType ScheduleType { get; set; }
        public List<Week>? Weeks { get; set; }
        public int CurrentWeekId { get; set; }
    }

    public enum ScheduleType
    {
        FullTime,
        ShiftTime
    }
}
