using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator.Calculator
{
    public class CalculationResult
    {
        public decimal Interest { get; set; }
        public IEnumerable<CalcDetailLine> Details { get; set; }
    }
}
