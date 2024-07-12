using AutoMapper;
using DSharpPlus.CommandsNext;
using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Profiles
{
    public class CommandsNextConfigurationProfile : Profile
    {
        public CommandsNextConfigurationProfile() 
        {
            CreateMap<CommandsConfiguration, CommandsNextConfiguration>();
        }
    }
}
