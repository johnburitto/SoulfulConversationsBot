using Schedule.Schedule;
using System.Text.Json;

var scheduler = new Scheduler();
var schedule = scheduler.GetFullTimeJobShedule(new()
{
    UserName = "JohnBuritto",
    BusyHours = "10:00-19:00",
    FreeHours = "8:00-9:00; 20:00-23:00",
    MaybeHours = "00:00-07:00"
});

Console.WriteLine(JsonSerializer.Serialize(schedule));