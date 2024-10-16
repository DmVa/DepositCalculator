namespace DepositCalculator.Calculator
{
    public class MonthlyCalc : InterestCalculatorBase
    {
        public override double Calc(double amount, int termMonthes, double rate, out IEnumerable<CalcResult> calculationDetails)
        {
            var details = new CalcResult[termMonthes];
            double interest = 0.0;
            for (int index = 0; index <= termMonthes - 1; index++)
            {
                CalcResult monthCalculation = new CalcResult()
                {
                    InitialFunded = amount,
                    ToCapitalization = 0,
                    ToChekout = amount * rate / 12
                };

                interest += monthCalculation.ToChekout;
                details[index] = monthCalculation;
            }

            calculationDetails = details;
            return interest;
        }
    }
}
