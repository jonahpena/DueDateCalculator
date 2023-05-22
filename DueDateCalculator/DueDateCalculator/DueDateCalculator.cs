using DueDateCalculator.Interfaces;

namespace DueDateCalculator;

public class DueDateCalculator : IDueDateCalculator
{
    private readonly IWorkingHours _workingHours;

    public DueDateCalculator(IWorkingHours workingHours)
    {
        _workingHours = workingHours;
    }

    
    public DateTime CalculateDueDate(DateTime submitDate, double turnaroundTime)
    {
        if (!_workingHours.IsWithinWorkingHours(submitDate) || _workingHours.IsWeekend(submitDate))
        {
            throw new ArgumentException("The submit date must be during working hours on a working day.");
        }

        if (turnaroundTime < 0)
        {
            throw new ArgumentException("The turnaround time cannot be negative.");
        }

        DateTime dueDate = submitDate;
        double hoursToAdd = 1.0;

        while (turnaroundTime > 0)
        {
            if (turnaroundTime < 1.0)
            {
                hoursToAdd = turnaroundTime;
            }
            dueDate = dueDate.AddHours(hoursToAdd);
            turnaroundTime -= hoursToAdd;

            if (dueDate.Hour >= _workingHours.EndHour || !_workingHours.IsWithinWorkingHours(dueDate) || _workingHours.IsWeekend(dueDate))
            {
                if (dueDate.Hour >= _workingHours.EndHour && dueDate.DayOfWeek != DayOfWeek.Friday)
                {
                    // Skip to the next day's start of the working day.
                    dueDate = dueDate.Date.AddDays(1).AddHours(_workingHours.StartHour);
                }
                else if (dueDate.Hour >= _workingHours.EndHour && dueDate.DayOfWeek == DayOfWeek.Friday)
                {
                    // If it's the end of the working day on Friday, skip to Tuesday.
                    dueDate = dueDate.Date.AddDays(4).AddHours(_workingHours.StartHour);
                }
                else if (dueDate.Hour < _workingHours.StartHour)
                {
                    dueDate = dueDate.Date.AddHours(_workingHours.StartHour);
                }
                else if (_workingHours.IsWeekend(dueDate))
                {
                    int daysUntilMonday = ((int)DayOfWeek.Monday - (int)dueDate.DayOfWeek + 7) % 7;
                    dueDate = dueDate.AddDays(daysUntilMonday);
                }

                // Subtract the hour that was added before checking the conditions.
                dueDate = dueDate.AddHours(-hoursToAdd);
                turnaroundTime += hoursToAdd;
            }
            hoursToAdd = 1.0; // Reset the hoursToAdd after each loop
        }

        // Add the minutes from the submit date to the due date.
        dueDate = dueDate.AddMinutes(submitDate.Minute);

        return dueDate;
    }
}
