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

        public decimal CalculateOvertimePay(int hoursWorkedWithOverTime, int hourlyRate, decimal overtimeFactor)
        {
            if (hoursWorkedWithOverTime <= regularPayInterval)
                return 0;

            return (hoursWorkedWithOverTime - regularPayInterval) * hourlyRate * overtimeFactor;
        }

        public decimal CalculateGrossPay(decimal regularPay, decimal overTimePay)
        {
            return regularPay + overTimePay;
        }
    }
}
