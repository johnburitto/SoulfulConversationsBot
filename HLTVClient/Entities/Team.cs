namespace HLTVClient.Entities
{
    public class Team
    {
        public string? Name { get; set; }
        public string? LogoThumbnails { get; set; }
        public string? Rank { get; set; }
        public int Points { get; set; }
        public string? Country { get; set; }
        public string? FlagThumbnails { get; set; }
        public int WeeeksInTop30 { get; set; }
        public float AveragePlayerAge { get; set; }
    }
}
