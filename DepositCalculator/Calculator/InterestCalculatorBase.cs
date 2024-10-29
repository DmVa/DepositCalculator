namespace DepositCalculator.Calculator
{
    public abstract class InterestCalculatorBase
    {
        public abstract decimal Calc(decimal amount, int termMonthes, decimal rate, out IEnumerable<CalcResult> calculationDetails);
    }
}
