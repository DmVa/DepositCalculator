namespace DepositCalculator.Calculator
{
    public abstract class InterestCalculatorBase
    {
        public abstract Task<CalculationResult> Calc(decimal amount, int termMonthes, decimal rate);
    }
}
