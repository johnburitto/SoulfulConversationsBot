using Schedule.Extensions;
using SoulfulConversationsBot.Extensions;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Schedule.Entities
{
    public class PersonSchedule
    {
        public string? UserName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ScheduleType ScheduleType { get; set; }
        public List<Week>? Weeks { get; set; }
        public int CurrentWeekId { get; set; } = 0;

        public string Fancy(bool isMobile = false)
        {
            var schedule = "";
            var dates = string.Join(" ", Weeks?[CurrentWeekId].Days?.ToDaysString("\t\t", isMobile));

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < Weeks?[CurrentWeekId].Days!.Count; j++)
                {
                    if (j == 0)
                    {
                        schedule += $"{Weeks[CurrentWeekId].Days![j].Hours![i].HourString}   {Weeks[CurrentWeekId].Days![j].Hours![i].AvailabilityString().Repeat(isMobile ? 1 : 2)} ";
                    }
                    else
                    {
                        schedule += $"{Weeks[CurrentWeekId].Days![j].Hours![i].AvailabilityString().Repeat(isMobile ? 1 : 2)} ";
                    }
                }

                schedule += "\n";
            };

            return $"{dates}\n\n{schedule}";
        }
    }

    public enum ScheduleType
    {
        FullTime,
        ShiftTime
    }
}
