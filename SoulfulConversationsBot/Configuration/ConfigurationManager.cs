using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SoulfulConversationsBot.Configuration
{
    public class ConfigurationManager
    {
        private static IConfiguration _configuration;
        private static object _lock = new object();

        public static IConfiguration Configuration => GetConfiguration();

        private static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                lock (_lock)
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("config.json", optional:false)
                        .Build();
                }
            }
            return _configuration;
        }

        public static void ConfigureBot()
        {
            IServiceCollection services = new ServiceCollection();
            services.Configure<DiscordConfiguration>(options => Configuration.GetSection("DiscordConfiguration").Bind(options));
            services.Configure<CommandsNextConfiguration>(options => Configuration.GetSection("CommandsNextConfiguration").Bind(options));
            
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            // Okay, this is clearly wrong:
            //var client = new DiscordClient(serviceProvider.GetService<IOptions<DiscordConfiguration>>());
            //Console.WriteLine("token: " + services.);
        }




        //    public DiscordConfiguration discordConfiguration = new DiscordConfiguration()
        //    {
        //        Intents = DiscordIntents.All,
        //        // NOTE: do not upload the token to Git for the security sake).
        //        // You can keep it in a file that is listed in .gitignore instead
        //        Token = jsonData.token,
        //        TokenType = TokenType.Bot,
        //        AutoReconnect = true
        //    };

        //    public CommandsNextConfiguration commandsNextConfiguration = new CommandsNextConfiguration()
        //    {
        //        StringPrefixes = ["!"],
        //        EnableMentionPrefix = true,
        //        EnableDms = true,
        //        EnableDefaultHelp = false
        //    };
    }
}

//IConfiguration
//_locked
// GetConfiguration() : if configuration is null: build configuration

// configure app: create all the objects etc.

// call in main: configurationManager.configureApp; var bot: createBot()


// TODO read about IOptions