using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class PayCalculator
    {
        public decimal CalculateRegularPay(
            decimal hoursWorked, decimal hourlyRate)
        {
            const int regularPayInterval = 40;
            if (hoursWorked <= regularPayInterval)
            {
                return hourlyRate * hoursWorked;
            }
            else
            {
                return regularPayInterval * hourlyRate;
            }
    }
}
