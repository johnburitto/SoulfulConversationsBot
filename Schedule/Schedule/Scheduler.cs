using Schedule.Dtos;
using Schedule.Entities;

namespace Schedule.Schedule
{
    public class Scheduler : IScheduler
    {
        public PersonSchedule GetFullTimeJobShedule(FullTimeJobScheduleDto dto)
        {
            throw new NotImplementedException();
        }

        public PersonSchedule GetShiftTimeJobShedule(ShiftTimeJobDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
