namespace DueDateCalculator;

public interface IWorkingHours
{
    int StartHour { get; }
    int EndHour { get; }
    bool IsWithinWorkingHours(DateTime dateTime);
    bool IsWeekend(DateTime date);
}