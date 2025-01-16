namespace Schedule.Entities
{
    public class Week : IFancy
    {
        public List<Day>? Days { get; set; }

        public string Fancy()
        {
            return string.Join("\n", Days!.Select(day => day.Fancy()));
        }
    }
}
