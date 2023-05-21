using NUnit.Framework;
using System;

namespace DueDateCalculator.Tests
{
    [TestFixture]
    public class DueDateCalculatorTests
    {
        private DueDateCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DueDateCalculator(new WorkingHours(9, 17));
        }

        [Test]
        public void CalculateDueDate_SubmitDateOnWeekend_ThrowsArgumentException()
        {
            DateTime submitDate = new DateTime(2023, 5, 21, 10, 0, 0); // This is a Sunday.
            Assert.Throws<ArgumentException>(() => _calculator.CalculateDueDate(submitDate, 16));
        }

        [Test]
        public void CalculateDueDate_SubmitDateOutsideOfWorkHours_ThrowsArgumentException()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 8, 0, 0); // This is before work hours.
            Assert.Throws<ArgumentException>(() => _calculator.CalculateDueDate(submitDate, 16));
        }

        [Test]
        public void CalculateDueDate_16HoursTurnaround_ReturnsCorrectDueDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 23, 14, 12, 0); // This is a Tuesday.
            DateTime expectedDueDate = new DateTime(2023, 5, 25, 14, 12, 0); // Expected due date is Thursday at the same time.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 16);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        [Test]
        public void CalculateDueDate_SubmitDateOnFridayAndTurnaroundOverWeekend_ReturnsCorrectDueDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 16, 0, 0); // This is a Friday at the end of work hours.
            DateTime expectedDueDate = new DateTime(2023, 5, 23, 10, 0, 0); // Expected due date is Tuesday at start of work hours.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 2);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        [Test]
        public void CalculateDueDate_ZeroTurnaround_ReturnsSubmitDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 10, 0, 0); // This is a Friday.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 0);
            Assert.AreEqual(submitDate, actualDueDate);
        }

        [Test]
        public void CalculateDueDate_NegativeTurnaround_ThrowsArgumentException()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 10, 0, 0); // This is a Friday.
            Assert.Throws<ArgumentException>(() => _calculator.CalculateDueDate(submitDate, -2));
        }
    }
}
