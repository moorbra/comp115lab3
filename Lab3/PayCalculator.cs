using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class PayCalculator
    {
        private const int regularPayInterval = 40;

        public decimal CalculateRegularPay(decimal hoursWorked, decimal hourlyRate)
        {            
            if (hoursWorked <= regularPayInterval)            
                return hourlyRate * hoursWorked;

            return regularPayInterval * hourlyRate;            
        }

        public decimal CalculateOvertimePay(decimal hoursWorked, decimal hourlyRate, decimal overtimeFactor)
        {
            if (hoursWorked <= regularPayInterval)
                return 0;

            return (hoursWorked - regularPayInterval) * hourlyRate * overtimeFactor;
        }

        public decimal CalculateGrossPay(decimal regularPay, decimal overTimePay)
        {
            return regularPay + overTimePay;
        }

        public decimal CalculateTaxRate(string maritalStatus)
        {
            switch(maritalStatus.ToLower())
            {
                case "m":
                    return .15m;
                case "s":
                    return .22m;
                case "d":
                    return .23m;
                case "w":
                    return .13m;
                default:
                    return 0;
            }
        }

        public decimal CalculateNetPay(decimal grossPay, decimal taxRate)
        {
            return grossPay * (1 - taxRate);
        }
    }
}
