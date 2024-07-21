using Schedule.Entities;

namespace Schedule.Dtos
{
    public class FullTimeJobScheduleDto
    {
        public string? UserName { get; set; }
        public string? FreeHours { get; set; }
        public string? MaybeHours { get; set; }
        public string? BusyHours { get; set; }
    }
}
