namespace Schedule.Entities
{
    public class Hour
    {
        public string? HourString { get; set; }
        public Availability Availability { get; set; }
    }

    public enum Availability
    {
        Free,
        Maybe,
        Busy
    }
}
