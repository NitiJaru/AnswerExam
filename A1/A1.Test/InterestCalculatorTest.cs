using System;
using Xunit;
using A1.Lib;
using System.Linq;
using FluentAssertions;

namespace A1.Test
{
    public class InterestCalculatorTest
    {

        [Theory(DisplayName = "Input correct, system should return correct result")]
        [InlineData(12, 10000, 1, "11200")]
        [InlineData(12, 10000, 2, "11200,12544")]
        [InlineData(12, 10000, 3, "11200,12544,14049.28")]
        [InlineData(12, 10000, 4, "11200,12544,14049.28,15735.1936")]
        public void InterestCalculator_Correct(int interestPercent, double principleAmount, int yearAmount, string expected)
        {
            var calculator = new InterestCalculator();
            calculator.SetInterestPercent(interestPercent);
            var result = calculator.Calculate(principleAmount, yearAmount);

            var expectedResult = expected.Split(',').Select(it => double.Parse(it));
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory(DisplayName = "Input incorrect, system should return empty result")]
        [InlineData(0, 10000, 1)]
        [InlineData(-1, 10000, 1)]
        [InlineData(12, 0, 1)]
        [InlineData(12, -1, 1)]
        [InlineData(12, 10000, 0)]
        [InlineData(12, 10000, -1)]
        public void InterestCalculator_Incorrect(int interestPercent, double principleAmount, int yearAmount)
        {
            var calculator = new InterestCalculator();
            calculator.SetInterestPercent(interestPercent);
            var result = calculator.Calculate(principleAmount, yearAmount);
        }
    }
}
