using System;
using static System.Console;

namespace NumericalAnalysis.Interpolation
{
    //To find a missing value from a range or group data
    public class NewtonDevidedDifference
    {
        private int[] valueOfX = { };
        private double[] valueOfY = { };
        private int length=6, i;
        double x=8;
        private double[] delY;
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

        public double[] BuildDiffTable()
        {
            delY = new double[length];
            i = 0;
            foreach (var val in valueOfY)
            {
                delY[i++] = val;
            }
            int y_th = 0, j = 0;
            double value1, value2;
            while (y_th < delY.Length - 1)
            {
                value1 = delY[y_th];
                value2 = delY[y_th + 1];
                for (i = y_th, j = 0; i < delY.Length - 1; i++, j++)
                {
                    delY[i + 1] = (value2 - value1) / (valueOfX[i+1] - valueOfX[j]);
                    value1 = value2;
                    if (i < delY.Length - 2)
                    {
                        value2 = delY[i + 2];
                    }
                }
                y_th++;
            }
            return delY;
        }

        public void ApplyFormula()
        {
            Result = delY[0];
            double x_diff_product = 1;
            for(i=1; i<length; i++)
            {
                x_diff_product *= (x - valueOfX[i - 1]);
                Result+= (x_diff_product * delY[i]);
            }

        }
    }
}
