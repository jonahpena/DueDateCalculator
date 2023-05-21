namespace DueDateCalculator;
public interface IDueDateCalculator
{
    DateTime CalculateDueDate(DateTime submitDate, double turnaroundTime);
}