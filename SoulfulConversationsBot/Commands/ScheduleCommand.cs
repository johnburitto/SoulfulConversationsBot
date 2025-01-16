using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Schedule.Schedule;

namespace SoulfulConversationsBot.Commands
{
    public class ScheduleCommand : BaseCommandModule
    {
        private Scheduler _scheduler;

        public ScheduleCommand()
        {
            _scheduler = new Scheduler();
        }
    

        [Command("schedule-test")]
        public async Task ExecuteAsync(CommandContext context)
        {
            var schedule = _scheduler.GetFullTimeJobShedule(new()
            {
                UserName = "JohnBuritto",
                BusyHours = "10:00-18:00",
                FreeHours = "8:00-9:00; 19:00-23:00",
                MaybeHours = "00:00-07:00"
            });
            var embedMessage = new DiscordEmbedBuilder()
            {
                Description = $"```{schedule.Fancy(context.Member!.Presence.ClientStatus.Mobile.HasValue)}```"
            };

            await context.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}
