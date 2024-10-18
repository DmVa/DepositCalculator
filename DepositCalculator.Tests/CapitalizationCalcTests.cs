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
            var interest = calc.Calc(1000, 12, 0.05, out calculationDetails);
            Assert.IsTrue(Math.Abs(interest - 51.16) < 0.01);
        }
    }
}