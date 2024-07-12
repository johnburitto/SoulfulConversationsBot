namespace SoulfulConversationsBot.Dto
{
    public class CommandsConfiguration
    {
        public IEnumerable<string>? StringPrefixes { get; set;}
        public bool EnableMentionPrefix { get; set;}
        public bool EnableDms { get; set;}
        public bool EnableDefaultHelp { get; set;}
    }
}
