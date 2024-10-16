namespace DepositCalculator.Calculator
{
    public class CalculatorFactoty
    {
        public static CalculatorFactoty Instance = new CalculatorFactoty();
        private CalculatorFactoty() 
        { 
        }
        public InterestCalculatorBase CreateCalculator(InterestPayType payType)
        {
            switch (payType)
            {
                case InterestPayType.Capitalization:
                    return new CapitalizationCalc();
                case InterestPayType.Monthly:
                    return new MonthlyCalc();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
