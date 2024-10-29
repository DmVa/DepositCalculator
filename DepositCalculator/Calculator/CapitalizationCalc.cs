namespace DepositCalculator.Calculator
{
    public class CapitalizationCalc: InterestCalculatorBase
    {
        public override decimal Calc(decimal amount, int termMonthes, decimal rate, out IEnumerable<CalcResult> calculationDetails)
        {
            var details = new CalcResult[termMonthes];
            var prevAmount = amount;
            var capitalization = amount * rate / 12;
            for (int i = 0; i <= termMonthes - 1; i++)
            {
                var calcResult = new CalcResult
                {
                    InitialFunded = prevAmount,
                    ToCapitalization = prevAmount * rate / 12,
                    ToChekout = 0
                };

                prevAmount = calcResult.InitialFunded + calcResult.ToCapitalization;
                details[i] = calcResult;
            }

            calculationDetails = details;
            if (termMonthes > 0)
            {
                var last = details[termMonthes - 1];
                return last.InitialFunded + last.ToCapitalization - amount;
            }

            return 0.0m;
        }
    }
}
