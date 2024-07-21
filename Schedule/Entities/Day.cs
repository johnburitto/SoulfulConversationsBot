namespace Schedule.Entities
{
    public class Day
    {
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public List<Hour>? Hours { get; set; }
    }
}
