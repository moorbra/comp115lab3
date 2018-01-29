using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab3.Tests
{
    [TestClass]
    public class PayCalculatorTests
    {
        [TestMethod]
        public void CalculateRegularPayWithoutOverTimeTest()
        {
            const int hoursWorkedFourty = 40;
            const int hoursWorkedLessThanFourty = 30;
            const int hourlyRate = 10;
            const decimal expectedRegularPayExactly40Hours = 400;
            const decimal expectedRegularPayLessThanFourtyHours = 300;

            PayCalculator payCalculator = new PayCalculator();

            decimal actualRegularPayExactly40Hours = payCalculator.CalculateRegularPay(hoursWorkedFourty, hourlyRate);
            Assert.IsTrue(expectedRegularPayExactly40Hours == actualRegularPayExactly40Hours, $"Expected regular pay for fourty hours {expectedRegularPayExactly40Hours} does not equal actual pay for fourty hours {actualRegularPayExactly40Hours}");

            decimal actualRegularPayLessThan40Hours = payCalculator.CalculateRegularPay(hoursWorkedLessThanFourty, hourlyRate);
            Assert.IsTrue(expectedRegularPayLessThanFourtyHours == actualRegularPayLessThan40Hours, $"Expected regular pay for less than fourty hours {expectedRegularPayLessThanFourtyHours} does not equal actual pay for less than fourty hours {actualRegularPayLessThan40Hours}");
        }

        [TestMethod]
        public void CalculateRegularPayWithOvertimeTest()
        {
            const int hoursWorked = 41;
            const int hourlyRate = 10;
            const decimal expectedRegularPay = 400;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualRegularPay = payCalculator.CalculateRegularPay(hoursWorked, hourlyRate);

            Assert.IsTrue(
                expectedRegularPay == actualRegularPay,
                $"Expected regular pay {expectedRegularPay} to equal actual pay {actualRegularPay}");
        }

        [TestMethod]
        public void CalculateOvertimePayWhenOvertimeIsPresentTest()
        {
            const int hoursWorkedWithOverTime = 41;
            const int hourlyRate = 10;
            const decimal expectedOvertimePay = 15;
            const decimal overtimeFactor = 1.5m;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualOvertimePay = payCalculator.CalculateOvertimePay(hoursWorkedWithOverTime, hourlyRate, overtimeFactor);

            Assert.IsTrue(expectedOvertimePay == actualOvertimePay,
                $"Expected overtime pay {expectedOvertimePay} to equal actual overtime pay {actualOvertimePay}");
        }

        [TestMethod]
        public void CalculateOvertimePayWhenOvertimeIsNotPresentTest()
        {
            const int hoursWorkedExactlyRegularPayInterval = 40;
            const int hoursWorkedLessThanRegularPayInterval = 39;
            const int hourlyRate = 10;
            const decimal expectedOvertimePay = 0;
            const decimal overtimeFactor = 1.5m;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualOvertimePayWhenHoursWorkedIsExactlyRegularPayInteveral = payCalculator.CalculateOvertimePay(hoursWorkedExactlyRegularPayInterval, hourlyRate, overtimeFactor);
            Assert.IsTrue(expectedOvertimePay == actualOvertimePayWhenHoursWorkedIsExactlyRegularPayInteveral,
                $"Expected overtime pay {expectedOvertimePay} when hours worked {hoursWorkedExactlyRegularPayInterval} is equal to the regular pay interval to equal actual overtime pay {actualOvertimePayWhenHoursWorkedIsExactlyRegularPayInteveral}");

            decimal actualOvertimePayWhenHoursWorkedIsLessThanRegularPayInteveral = payCalculator.CalculateOvertimePay(hoursWorkedLessThanRegularPayInterval, hourlyRate, overtimeFactor);
            Assert.IsTrue(expectedOvertimePay == actualOvertimePayWhenHoursWorkedIsLessThanRegularPayInteveral,
                $"Expected overtime pay {expectedOvertimePay} when hours worked {hoursWorkedLessThanRegularPayInterval} is equal to the regular pay interval to equal actual overtime pay {actualOvertimePayWhenHoursWorkedIsLessThanRegularPayInteveral}");
        }

        [TestMethod]
        public void CalculateGrossPayTest()
        {
            const decimal regularPay = 400;
            const decimal overTimePay = 100;
            const decimal expectedGrossPay = 500;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualGrossPay = payCalculator.CalculateGrossPay(regularPay, overTimePay);
            Assert.IsTrue(actualGrossPay == expectedGrossPay, $"Expected gross pay {expectedGrossPay}. Actual gross pay {actualGrossPay}");
        }
    }
}
