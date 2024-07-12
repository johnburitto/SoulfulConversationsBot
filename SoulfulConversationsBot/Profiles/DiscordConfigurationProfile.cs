using AutoMapper;
using DSharpPlus;
using SoulfulConversationsBot.Dto;

namespace SoulfulConversationsBot.Profiles
{
    public class DiscordConfigurationProfile : Profile
    {
        public DiscordConfigurationProfile() 
        {
            CreateMap<BotConfigurationDto, DiscordConfiguration>();
        }
    }
}
