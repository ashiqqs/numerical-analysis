using System;
using static System.Console;

namespace NumericalAnalysis.Integral
{
    public class SimsonThreeEightRule
    {
        private double lowerLimit, upperLimit, h;
        private int n, i; // n:interval should be even
        public double Result { get; private set; }

        public void TakeInput()
        {
            Write("Enter the value of Lower Limit: ");
            lowerLimit = double.Parse(ReadLine());
            Write("Enter the value of Upper Limit: ");
            upperLimit = double.Parse(ReadLine());

            Write("How many interval you want to devide: ");
            n = int.Parse(ReadLine());
            h = (upperLimit - lowerLimit) / n;
        }

        public void ApplyFormula()
        {
            Result = f(lowerLimit) + f(upperLimit);
            double interval = lowerLimit;
            for (i = 1; i < n; i++)
            {
                interval += h;
                if (i!=3 && i<n)
                {
                    Result += (3 * f(interval));
                }
                if (i % 3 == 0 && i <= n)
                {
                    Result += (2 * f(interval));
                }
            }
            Result *= (3 * h / 8);
        }


        private double f(double x)
        {
            //Given f(x) = 1/x
            return 1 / x;
        }
    }
}
