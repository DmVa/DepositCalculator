using DepositCalculator.Calculator;

namespace DepositCalculator.Tests
{
    [TestClass]
    public class CapitalizationCalcTests
    {
        [TestMethod]
        public async Task CapitalizationCalc_Calc_CalcYear()
        {
            CapitalizationCalc calc = new CapitalizationCalc();
            var calcResult = await calc.Calc(1000, 12, 0.05m);
            Assert.IsTrue(Math.Abs(calcResult.Interest - 51.16m) < 0.01m);
        }
    }
}