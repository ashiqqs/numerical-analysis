using System;
using System.Reflection.Emit;
using static System.Console;

namespace NumericalAnalysis.Integral
{
    /// <summary>
    /// It is used when it is very difficult to solve the given integral mathematically.
    /// This rule gives approximation easily without actually knowing the integration rules.
    /// </summary>
    public class SimsonsOneThirdRule
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

            IntervalShouldBeEven:
            Write("How many interval you want to devide: ");
            n = int.Parse(ReadLine());
            if (n % 2 != 0) { goto IntervalShouldBeEven; }
            h = (upperLimit - lowerLimit) / n;
        }

        public void ApplyFormula()
        {
            Result = f(lowerLimit) + f(upperLimit);
            double interval = lowerLimit;
            for (i = 1; i < n; i++)
            {
                interval += h;
                if (i % 2 == 0 && i<n-1) {
                    Result += (2* f(interval));
                }
                if (i % 2 != 0 && i<n) {
                    Result += (4 * f(interval));
                 }
            }
            Result *= h / 3;
        }


        private double f(double x)
        {
            //Given f(x) = log(x)
            return Math.Log(x);
        }
    }
}
