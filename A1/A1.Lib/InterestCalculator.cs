using System;
using System.Collections.Generic;
using System.Linq;

namespace A1.Lib
{
    public class InterestCalculator
    {
        private int InterestPercent;

        public void SetInterestPercent(int interestPercent)
        {
            InterestPercent = interestPercent;
        }

        public IEnumerable<double> Calculate(double principleAmount, int yearAmount)
        {
            const int MinimumValue = 1;
            var isDataValid = InterestPercent >= MinimumValue &&
                              principleAmount >= MinimumValue &&
                              yearAmount >= MinimumValue;
            if(!isDataValid)  return Enumerable.Empty<double>();

            var result = new List<double>();
            var interest = (double)InterestPercent / 100;
            for (int currentYear = 0; currentYear < yearAmount; currentYear++)
            {
                var value = result.LastOrDefault();
                var amount = principleAmount;
                if (value > 0) amount = value;

                var calculate = amount + amount * interest;
                result.Add(calculate);
            }
            return result;
        }
    }
}
