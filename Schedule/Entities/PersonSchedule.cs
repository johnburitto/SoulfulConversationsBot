namespace Schedule.Entities
{
    public class PersonSchedule
    {
        public string? UserName { get; set; }
        public List<Week>? Weeks { get; set; }
        public int CurrentWeekId { get; set; }
    }
}
