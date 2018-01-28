using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            const decimal overtimeFactor = 1.5m;
            const decimal marriedTaxRate = .15m;
            const decimal singleTaxRate = .22m;
            const decimal divorcedTaxRate = .23m;
            const decimal widowedTaxRate = .13m;
            const int regularPayPeriod = 40;

            decimal hoursWorked = 0; 
            decimal hourlyRate = 0;            
            string maritalStatus = string.Empty;
            bool hasOvertime = false;
            decimal overTimePay = 0;
            decimal taxRate = 0;
            decimal netPay = 0;
            decimal grossPay = 0;

            Console.Write("Please enter your hours worked: ");
            hoursWorked = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter your hourly rate: ");
            hourlyRate = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter your marital status (M)Married, (S)Single, (D)Divorved, (W)Widowed: ");
            maritalStatus = Console.ReadLine();

            hasOvertime = hoursWorked > regularPayPeriod ? true : false;

            decimal regularPay = 0;
            regularPay = hourlyRate * hoursWorked;
            if (hasOvertime)
            {
                regularPay = regularPayPeriod * hourlyRate;
                overTimePay = (hoursWorked - regularPayPeriod) * hourlyRate * overtimeFactor;
            }

            switch(maritalStatus.ToLower())
            {
                case "m":
                    taxRate = marriedTaxRate;
                    break;
                case "s":
                    taxRate = singleTaxRate;
                    break;
                case "w":
                    taxRate = widowedTaxRate;
                    break;
                case "d":
                    taxRate = divorcedTaxRate;
                    break;
            }

            grossPay = regularPay + overTimePay;
            netPay = grossPay * (1 - taxRate);

            Console.WriteLine($"Hours Worked: {hoursWorked}");
            Console.WriteLine($"Hourly Rate: {hourlyRate}");
            Console.WriteLine($"Tax Rate: {taxRate}");            
            if (hasOvertime)
            {
                Console.WriteLine($"Regular Pay: {regularPay:c}");
                Console.WriteLine($"Overtime Pay: {overTimePay:c}");
            }
            Console.WriteLine($"Gross Pay: {grossPay:c}");
            Console.WriteLine($"Net Pay: {netPay:c}");
            Console.ReadLine();
        }
    }
}
