namespace SoulfulConversationsBot.Dto
{
	/// <summary>
	/// Commands configuration.
	/// </summary>
	public class CommandsConfiguration
	{
		/// <summary>
		/// Gets or sets tring prefixes.
		/// </summary>
		public IEnumerable<string>? StringPrefixes { get; set;}

		/// <summary>
		/// Gets or sets whether to enable mention prefix.
		/// </summary>
		public bool EnableMentionPrefix { get; set;}

		/// <summary>
		/// Gets or sets whether to enable DMs.
		/// </summary>
		public bool EnableDms { get; set;}

		/// <summary>
		/// Gets or sets whether to enable default help command.
		/// </summary>
		public bool EnableDefaultHelp { get; set;}
	}
}
