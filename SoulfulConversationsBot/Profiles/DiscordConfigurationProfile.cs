using AutoMapper;

using DSharpPlus;

using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Profiles
{
	/// <summary>
	/// Discord configuration profile.
	/// </summary>
	public class DiscordConfigurationProfile : Profile
	{
		#region Constructor

		/// <summary>
		/// Creates a new instance of the <see cref="DiscordConfigurationProfile"/> class.
		/// </summary>
		public DiscordConfigurationProfile() 
		{
			CreateMap<BotConfigurationDto, DiscordConfiguration>();
		}

		#endregion
	}
}