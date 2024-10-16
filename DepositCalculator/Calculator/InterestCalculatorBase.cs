namespace DepositCalculator.Calculator
{
    public abstract class InterestCalculatorBase
    {
        public abstract double Calc(double amount, int termMonthes, double rate, out IEnumerable<CalcResult> calculationDetails);
    }
}
