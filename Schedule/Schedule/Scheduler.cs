using Schedule.Dtos;
using Schedule.Entities;

namespace Schedule.Schedule
{
    public class Scheduler : IScheduler
    {
        public PersonSchedule GetFullTimeJobShedule(FullTimeJobScheduleDto dto)
        {
            var freeHoursInterval = GetHoursInterval(dto.FreeHours ?? "");
            var busyHoursInterval = GetHoursInterval(dto.BusyHours ?? "");
            var maybeHoursInterval = GetHoursInterval(dto.MaybeHours ?? "");
            var hourIterator = DateTime.Now.Date.TimeOfDay;
            var hours = new List<Hour>();

            for (int i = 0; i < 24; i++)
            {
                hours.Add(DetermineHour(hourIterator, freeHoursInterval, busyHoursInterval, maybeHoursInterval));
                hourIterator += TimeSpan.FromHours(1);
            }

            return new PersonSchedule
            {
                UserName = dto.UserName,
                ScheduleType = ScheduleType.FullTime,
                Weeks = [GenerateFullTimeJobWeek(hours)],
                CurrentWeekId = 0
            };
        }

        public PersonSchedule GetShiftTimeJobShedule(ShiftTimeJobDto dto)
        {
            throw new NotImplementedException();
        }

        private List<TimeSpan>? GetHoursInterval(string interval)
        {
            if (interval == "")
            {
                return null;
            }

            var intervals = interval.Split(";");
            var hours = new List<TimeSpan>();

            foreach (var _ in intervals)
            {
                var startAndEnd = _.Split("-");
                var start = TimeSpan.Parse(startAndEnd[0]);
                var end = TimeSpan.Parse(startAndEnd[1]);

                for (var i = start; i <= end; i += TimeSpan.FromHours(1))
                {
                    hours.Add(i);
                }
            }

            return hours;
        }

        private Hour DetermineHour(TimeSpan hourIterator, List<TimeSpan>? freeHoursInterval, List<TimeSpan>? busyHoursInterval, List<TimeSpan>? maybeHoursInterval)
        {
            if (freeHoursInterval != null && freeHoursInterval.Contains(hourIterator))
            {
                return new()
                {
                    HourString = hourIterator.ToString(),
                    Availability = Availability.Free
                };
            }
            else if (busyHoursInterval != null && busyHoursInterval.Contains(hourIterator))
            {
                return new()
                {
                    HourString = hourIterator.ToString(),
                    Availability = Availability.Busy
                };
            }
            else if (maybeHoursInterval != null && maybeHoursInterval.Contains(hourIterator))
            {
                return new()
                {
                    HourString = hourIterator.ToString(),
                    Availability = Availability.Maybe
                };
            }
            else
            {
                return new()
                {
                    HourString = hourIterator.ToString(),
                    Availability = Availability.Unknown
                };
            }
        }

        private Week GenerateFullTimeJobWeek(List<Hour> hours)
        {
            var days = new List<Day>();
            var dateIterator = GetLastMondayDate();

            for (int i = 0; i < 7; i++)
            {
                days.Add(new()
                {
                    Date = dateIterator,
                    Hours = hours
                });
                dateIterator += TimeSpan.FromDays(1);
            }

            return new() 
            { 
                Days = days 
            };
        }

        private DateTime GetLastMondayDate()
        {
            DateTime today = DateTime.Today;
            int daysSinceLastMonday = (int)today.DayOfWeek - (int)DayOfWeek.Monday;

            if (daysSinceLastMonday < 0)
            {
                daysSinceLastMonday += 7;
            }

            return today.AddDays(-daysSinceLastMonday).Date;
        }
    }
}
