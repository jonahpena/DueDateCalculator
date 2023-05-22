namespace DueDateCalculator.Interfaces;
public interface IDueDateCalculator
{
    DateTime CalculateDueDate(DateTime submitDate, double turnaroundTime);
}