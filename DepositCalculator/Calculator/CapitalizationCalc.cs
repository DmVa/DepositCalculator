namespace DepositCalculator.Calculator
{
    public class CapitalizationCalc: InterestCalculatorBase
    {
        public override Task<CalculationResult> Calc(decimal amount, int termMonthes, decimal rate)
        {
            var task = new Task<CalculationResult>(()=>
            {
                var result = new CalculationResult();
                var details = new CalcDetailLine[termMonthes];
                var prevAmount = amount;
                var capitalization = amount * rate / 12;
                for (int i = 0; i <= termMonthes - 1; i++)
                {
                    var calcResult = new CalcDetailLine
                    {
                        InitialFunded = prevAmount,
                        ToCapitalization = prevAmount * rate / 12,
                        ToChekout = 0
                    };

                    prevAmount = calcResult.InitialFunded + calcResult.ToCapitalization;
                    details[i] = calcResult;
                }

                result.Details = details;
                if (termMonthes > 0)
                {
                    var last = details[termMonthes - 1];
                    result.Interest = last.InitialFunded + last.ToCapitalization - amount;
                }
                return result;
            }
            );
            task.Start();

            return task;
        }
    }
}
