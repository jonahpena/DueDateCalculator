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
        [Test]
        public void CalculateDueDate_VeryLargeTurnaround_ReturnsCorrectDueDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 23, 14, 12, 0); // This is a Tuesday.
            DateTime expectedDueDate = new DateTime(2023, 8, 15, 14, 12, 0); // Expected due date is three months later, ignoring weekends.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 16 * 20 * 12); // 16 hours/day, 20 days/month, 12 months
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        [Test]
        public void CalculateDueDate_SubmitTimeAtStartOfWorkDay_ReturnsCorrectDueDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 9, 0, 0); // This is a Friday at the start of work hours.
            DateTime expectedDueDate = new DateTime(2023, 5, 19, 13, 0, 0); // Expected due date is four hours later on the same day.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 4);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        [Test]
        public void CalculateDueDate_NonIntegerTurnaround_ReturnsCorrectDueDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 9, 0, 0); // This is a Friday at the start of work hours.
            DateTime expectedDueDate = new DateTime(2023, 5, 19, 13, 30, 0); // Expected due date is 4.5 hours later on the same day.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 4.5);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        [Test]
        public void CalculateDueDate_SubmitOnFridayEndWith72HoursTurnaround_ReturnsCorrectDueDate()
        {
            DateTime submitDate = new DateTime(2023, 5, 19, 16, 0, 0); // This is a Friday at the end of work hours.
            DateTime expectedDueDate = new DateTime(2023, 5, 24, 16, 0, 0); // Expected due date is Wednesday at the end of work hours.

            DateTime actualDueDate = _calculator.CalculateDueDate(submitDate, 72); // 72 hours turnaround time.
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        
        
        
    }
}
