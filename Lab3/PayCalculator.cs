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

        public decimal CalculateOvertime(int hoursWorkedWithOverTime, int hourlyRate, decimal overtimeFactor)
        {
            if (hoursWorkedWithOverTime <= regularPayInterval)
                return 0;

            return (hoursWorkedWithOverTime - regularPayInterval) * hourlyRate * overtimeFactor;
        }
    }
}
