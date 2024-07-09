using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity.Extensions;
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
                        .AddJsonFile("appsettings.json", optional:false)
                        .Build();
                }
            }
            return _configuration;
        }

        public static DiscordClient ConfigureDiscordClient()
        {
            IServiceCollection services = new ServiceCollection();
            services.Configure<DiscordConfiguration>(options => Configuration.GetSection("DiscordConfiguration").Bind(options));
            services.Configure<CommandsNextConfiguration>(options => Configuration.GetSection("CommandsNextConfiguration").Bind(options));

            
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            DiscordConfiguration tmp = serviceProvider.GetService<IOptions<DiscordConfiguration>>()!.Value;

            var discordClient = new DiscordClient(tmp);
            var commands = discordClient.UseCommandsNext(serviceProvider.GetService<IOptions<CommandsNextConfiguration>>()!.Value);

            discordClient.UseInteractivity(new()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            discordClient.Ready += ClientReadyAsync ;

            return discordClient;
            //await discordClient.ConnectAsync();
            //await Task.Delay(-1);

            //var assembly = AppDomain.CurrentDomain.GetAssemblies();

            // TODO refactor config
            // explore assembly object and exctract command data;
            // create a temporary manual configuration for the commands;
            // push changes
        }

        private static Task ClientReadyAsync (DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

