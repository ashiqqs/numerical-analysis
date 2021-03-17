using System;
using static System.Console;

namespace NumericalAnalysis.Integral
{
    //To find the exact value of a definite integral 
    public class TrapezoidalRule
    {
        private double lowerLimit, upperLimit, delX;
        private int n,i;
        public double Result { get; private set; }

        public void TakeInput()
        {
            Write("Enter the value of Lower Limit: ");
            lowerLimit = double.Parse(ReadLine());
            Write("Enter the value of Upper Limit: ");
            upperLimit = double.Parse(ReadLine());
            Write("How many interval you want to devide: ");
            n = int.Parse(ReadLine());

            delX = (upperLimit - lowerLimit) / n;
        }

        public void ApplyFormula()
        {
            double interval = lowerLimit;
            Result = f(lowerLimit);
            for (i=1; i<n; i++)
            {
                interval += delX;
                Result += 2*f(interval);
            }
            Result += f(upperLimit);
            Result *= delX / 2;
        }


        private double f(double xthInterval)
        {
            //Given f(x) = Root(1+x^2)
            return Math.Sqrt(1 + (xthInterval * xthInterval));
        }


    }
}
