using DepositCalculator.Calculator;

namespace DepositCalculator.Tests
{
    [TestClass]
    public class CapitalizationCalcTests
    {
        [TestMethod]
        public void CapitalizationCalc_Calc_CalcYear()
        {
            CapitalizationCalc calc = new CapitalizationCalc();
            IEnumerable<CalcResult> calculationDetails;
            var interest = calc.Calc(1000, 12, 0.05m, out calculationDetails);
            Assert.IsTrue(Math.Abs(interest - 51.16m) < 0.01m);
        }
    }
}