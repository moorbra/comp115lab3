using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab3.Tests
{
    [TestClass]
    public class UnitTest1
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

            decimal actualRegularPayExactly40Hours = 
                payCalculator.CalculateRegularPay(hoursWorkedFourty,
                hourlyRate);

            Assert.IsTrue(expectedRegularPayExactly40Hours 
                == actualRegularPayExactly40Hours,
                $"Expected regular pay for fourty hours " +
                $"{expectedRegularPayExactly40Hours} " +
                $"does not equal actual pay for " +
                $"fourty hours {actualRegularPayExactly40Hours}");
        }

        [TestMethod]
        public void CalculateRegularPayWithOvertimeTest()
        {
            const int hoursWorked = 41;
            const int hourlyRate = 10;
            const decimal expectedRegularPay = 400;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualRegularPay = 
                payCalculator.CalculateRegularPay(hoursWorked, hourlyRate);

            Assert.IsTrue(
                expectedRegularPay == actualRegularPay, 
                $"Expected regular pay {expectedRegularPay} to equal actual pay {actualRegularPay}");
        }
    }
}
