using Schedule.Dtos;
using Schedule.Entities;

namespace Schedule.Schedule
{
    public interface IScheduler
    {
        PersonSchedule GetFullTimeJobShedule(FullTimeJobScheduleDto dto);
        PersonSchedule GetShiftTimeJobShedule(ShiftTimeJobDto dto);
    }
}
