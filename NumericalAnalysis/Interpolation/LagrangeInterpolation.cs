using System;
using static System.Console;
namespace NumericalAnalysis.Interpolation
{
    //To find the missing value when the value of x is not in sequence.
    public class LagrangesInterpolation
    {
        private int[] valueOfX = {5,6,9,11 };
        private double[] valueOfY = { 12,13,14,16};
        private int length=4, i;
        private double x=10;
        public double Result { get; private set; }

        public void TakeInput()
        {
            Write("How many number you have? ");
            length = int.Parse(ReadLine());
            valueOfX = new int[length];
            valueOfY = new double[length];
            for (i = 0; i < length; i++)
            {
                Write($"x{i + 1} = ");
                valueOfX[i] = int.Parse(ReadLine());
                Write($"y{i + 1} = ");
                valueOfY[i] = double.Parse(ReadLine());
            }

            Write("Enter the value missing x = ");
            x = int.Parse(ReadLine());
        }

        public void ApplyFormula()
        {
            for(i=0; i<length; i++)
            {
                Result += (get_numerator(i) / get_denominatorz(i)) * valueOfY[i];
            }
        }

        //Get Divisor
        private double get_numerator(int Xth,double product=1, int index=0)
        {
            if (index >= length) { return product; }
            if (index == Xth) { return get_numerator(Xth, product, ++index); }
            return get_numerator(Xth, (x - valueOfX[index]) * product, ++index);
        }
        //Get Divider
        private double get_denominatorz(int Xth, double product=1, int index=0)
        {
            if (index >= length) { return product; }
            if (index == Xth) { return get_denominatorz(Xth, product, ++index); }
            return get_denominatorz(Xth, (valueOfX[Xth] - valueOfX[index]) * product, ++index);
        }
    }
}
