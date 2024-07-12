using AutoMapper;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using SoulfulConversationsBot.Configuration;
using SoulfulConversationsBot.Dto;
using SoulfulConversationsBot.Profiles;

namespace SoulfulConversationsBot.Bot
{
    public class BotBuilder
    {
        private DiscordBot _bot;
        private IMapper? _mapper;

        public BotBuilder() 
        { 
            _bot = new DiscordBot();
        }

        public BotBuilder ConfigureSystem()
        {
            ConfigurationManager.Configure();

            return this;
        }

        public BotBuilder ConfigureAutoMapper()
        {
            _mapper = new Mapper(new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new DiscordConfigurationProfile());
                configuration.AddProfile(new CommandsNextConfigurationProfile());
            }));

            return this;
        }

        public BotBuilder ConfigureBot()
        {
            var configrationDto = ConfigurationManager.GetOptions<BotConfigurationDto>()?.Value;
            var configuration = _mapper?.Map<DiscordConfiguration>(configrationDto);

            _bot.Configure(configuration);

            return this;
        }
        
        public BotBuilder ConfigureCommands()
        {
            var configrationDto = ConfigurationManager.GetOptions<CommandsConfiguration>()?.Value;
            var configuration = _mapper?.Map<CommandsNextConfiguration>(configrationDto);

            _bot.ConfigureCommands(configuration);

            return this;
        }

        public DiscordBot Build()
        {
            return _bot;
        }
    }
}
