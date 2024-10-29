using DepositCalculator.Calculator;

namespace DepositCalculator.Tests
{
    [TestClass]
    public class MonthlyCalcTests
    {
        [TestMethod]
        public void MonthlyCalc_Calc_CalcYear()
        {
            MonthlyCalc calc = new MonthlyCalc();
            IEnumerable<CalcResult> calculationDetails;
            var interest = calc.Calc(1000, 12, 0.05m, out calculationDetails);
            Assert.IsTrue(Math.Abs(interest - 50.00m) < 0.01m);
        }
    }
}