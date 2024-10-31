using DepositCalculator.Calculator;

namespace DepositCalculator.Tests
{
    [TestClass]
    public class MonthlyCalcTests
    {
        [TestMethod]
        public async Task MonthlyCalc_Calc_CalcYear()
        {
            MonthlyCalc calc = new MonthlyCalc();
            var calcResult = await calc.Calc(1000, 12, 0.05m);
            Assert.IsTrue(Math.Abs(calcResult.Interest - 50.00m) < 0.01m);
        }
    }
}