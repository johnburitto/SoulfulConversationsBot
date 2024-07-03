using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace SoulfulConversationsBot.Configuration
{
    public class Configuration
    {
        private DiscordConfiguration discordConfiguration { get; set; }
        private CommandsNextConfiguration commandsNextConfiguration { get; set; }
        private DiscordClient discordClient { get; set; }

        public Configuration(DiscordConfiguration discordConfiguration, CommandsNextConfiguration commandsNextConfiguration, DiscordClient discordClient)
        {
            this.discordConfiguration = discordConfiguration;
            this.commandsNextConfiguration = commandsNextConfiguration;
            this.discordClient = discordClient;
        }
    }


}
