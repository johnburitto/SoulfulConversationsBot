using AutoMapper;

using DSharpPlus.CommandsNext;

using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Profiles
{
	/// <summary>
	/// Commads configuration profile.
	/// </summary>
	public class CommandsNextConfigurationProfile : Profile
	{
		#region Constructor

		/// <summary>
		/// Creates a new instance of <see cref="CommandsNextConfigurationProfile"/> class.
		/// </summary>
		public CommandsNextConfigurationProfile() 
		{
			CreateMap<CommandsConfiguration, CommandsNextConfiguration>();
		}

		#endregion
	}
}
