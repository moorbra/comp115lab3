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
            decimal hoursWorked = 0; 
            decimal hourlyRate = 0;            
            string maritalStatus = string.Empty;

            // Collect input from the user
            Console.Write("Please enter your hours worked: ");
            hoursWorked = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter your hourly rate: ");
            hourlyRate = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter your marital status (M)Married, (S)Single, (D)Divorved, (W)Widowed: ");
            maritalStatus = Console.ReadLine();

            // Perform the calculations
            PayCalculator payCalculator = new PayCalculator();
            decimal regularPay = payCalculator.CalculateRegularPay(hoursWorked, hourlyRate);
            decimal overtimePay = payCalculator.CalculateOvertimePay(hoursWorked, hourlyRate, 1.5m);
            decimal grossPay = payCalculator.CalculateGrossPay(regularPay, overtimePay);
            decimal taxRate = payCalculator.CalculateTaxRate(maritalStatus);
            decimal netPay = payCalculator.CalculateNetPay(grossPay, taxRate);

            // Output results
            Console.WriteLine($"Hours Worked: {hoursWorked}");
            Console.WriteLine($"Hourly Rate: {hourlyRate}");
            Console.WriteLine($"Tax Rate: {taxRate}");            
            if (overtimePay > 0)
            {
                Console.WriteLine($"Regular Pay: {regularPay:c}");
                Console.WriteLine($"Overtime Pay: {overtimePay:c}");
            }
            Console.WriteLine($"Gross Pay: {grossPay:c}");
            Console.WriteLine($"Net Pay: {netPay:c}");
            Console.ReadLine();
        }
    }
}
