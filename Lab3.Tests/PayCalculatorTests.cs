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

        [TestMethod]
        public void GetTaxRateTest()
        {
            const string marriedUpper = "M";
            const string singleUpper = "S";
            const string widowedUpper = "W";
            const string divorcedUpper = "D";
            const string marriedLower = "m";
            const string singleLower = "s";
            const string widowedLower = "w";
            const string divorcedLower = "d";
            const decimal expectedMarriedTaxRate = .15m;
            const decimal expectedSingleTaxRate = .22m;
            const decimal expectedWidowedTaxRate = .13m;
            const decimal expectedDivorcedTaxRate = .23m;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualMarriedTaxRateUpper = payCalculator.CalculateTaxRate(marriedUpper);
            Assert.IsTrue(expectedMarriedTaxRate == actualMarriedTaxRateUpper, $"Expected married tax rate {expectedMarriedTaxRate} when marital status is {marriedUpper}. Actual tax rate {actualMarriedTaxRateUpper}");

            decimal actualMarriedTaxRateLower = payCalculator.CalculateTaxRate(marriedLower);
            Assert.IsTrue(expectedMarriedTaxRate == actualMarriedTaxRateUpper, $"Expected married tax rate {expectedMarriedTaxRate} when marital status is {marriedLower}. Actual tax rate {actualMarriedTaxRateLower}");

            decimal actualSingleTaxRateUpper = payCalculator.CalculateTaxRate(singleUpper);
            Assert.IsTrue(expectedSingleTaxRate == actualSingleTaxRateUpper, $"Expected single tax rate {expectedSingleTaxRate} when marital status is {singleUpper}. Actual tax rate {actualSingleTaxRateUpper}");

            decimal actualSingleTaxRateLower = payCalculator.CalculateTaxRate(singleLower);
            Assert.IsTrue(expectedSingleTaxRate == actualSingleTaxRateUpper, $"Expected single tax rate {expectedSingleTaxRate} when marital status is {singleLower}. Actual tax rate {actualSingleTaxRateLower}");

            decimal actualDivorcedTaxRateUpper = payCalculator.CalculateTaxRate(divorcedUpper);
            Assert.IsTrue(expectedDivorcedTaxRate == actualDivorcedTaxRateUpper, $"Expected divorced tax rate {expectedDivorcedTaxRate} when marital status is {divorcedUpper}. Actual tax rate {actualDivorcedTaxRateUpper}");

            decimal actualDivorcedTaxRateLower = payCalculator.CalculateTaxRate(divorcedLower);
            Assert.IsTrue(expectedDivorcedTaxRate == actualDivorcedTaxRateUpper, $"Expected divorced tax rate {expectedDivorcedTaxRate} when marital status is {divorcedLower}. Actual tax rate {actualDivorcedTaxRateLower}");

            decimal actualWidowedTaxRateUpper = payCalculator.CalculateTaxRate(widowedUpper);
            Assert.IsTrue(expectedWidowedTaxRate == actualWidowedTaxRateUpper, $"Expected widowed tax rate {expectedWidowedTaxRate} when marital status is {widowedUpper}. Actual tax rate {actualWidowedTaxRateUpper}");

            decimal actualWidowedTaxRateLower = payCalculator.CalculateTaxRate(widowedLower);
            Assert.IsTrue(expectedWidowedTaxRate == actualWidowedTaxRateUpper, $"Expected widowed tax rate {expectedWidowedTaxRate} when marital status is {widowedLower}. Actual tax rate {actualWidowedTaxRateLower}");
        }

        [TestMethod]
        public void GetNetPayTest()
        {
            const decimal grossPay = 1000;
            const decimal taxRate = .10m;
            const decimal expectedNetPay = 900;

            PayCalculator payCalculator = new PayCalculator();
            decimal actualNetPay = payCalculator.CalculateNetPay(grossPay, taxRate);
            Assert.IsTrue(expectedNetPay == actualNetPay, $"Expected net pay {expectedNetPay}. Actual net pay {actualNetPay}");
        }
    }
}
