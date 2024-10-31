namespace DepositCalculator.Calculator
{
    public class MonthlyCalc : InterestCalculatorBase
    {
        public override Task<CalculationResult> Calc(decimal amount, int termMonthes, decimal rate)
        {
            var task = new Task<CalculationResult>(() =>
            {
                var result = new CalculationResult();
                var details = new CalcDetailLine[termMonthes];
                decimal interest = 0.0m;
                for (int index = 0; index <= termMonthes - 1; index++)
                {
                    CalcDetailLine monthCalculation = new CalcDetailLine()
                    {
                        InitialFunded = amount,
                        ToCapitalization = 0,
                        ToChekout = amount * rate / 12
                    };

                    interest += monthCalculation.ToChekout;
                    details[index] = monthCalculation;
                }

                result.Details = details;
                result.Interest = interest;
                return result;
            });
            task.Start();
            return task;
        
        }
    }
}
