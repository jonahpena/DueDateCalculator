namespace DueDateCalculator
{
    public class WorkingHours : IWorkingHours
    {
        public int StartHour { get; private set; }
        public int EndHour { get; private set; }

        public WorkingHours(int startHour, int endHour)
        {
            if (startHour >= endHour)
            {
                throw new ArgumentException("Start hour must be less than end hour.");
            }

            StartHour = startHour;
            EndHour = endHour;
        }

        public bool IsWithinWorkingHours(DateTime dateTime)
        {
            return dateTime.Hour >= StartHour && dateTime.Hour < EndHour;
        }

        public bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
