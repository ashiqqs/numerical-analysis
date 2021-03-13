using System;
using static System.Console;

namespace NumericalAnalysis.Interpolation
{

    public class GregoryNewtonForward
    {
        private int[] valueOfX = { };
        private double[] valueOfY = { };
        private int length, i;
        private double x, h;
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

                if (i == 1)
                {
                    h = valueOfX[1] - valueOfX[0];
                }
                if(i>1 && (valueOfX[i] - valueOfX[i - 1]) != h)
                {
                    WriteLine("Invalid Interval!. Your previous interval is " + h);
                    i--;
                }
            }

            Write("Enter the value missing x = ");
            x = int.Parse(ReadLine());
        }

        public double[] BuildDiffTable()
        {
            delY = new double[length];
            i = 0;
            foreach(var val in valueOfY)
            {
                delY[i++] = val;
            }
            int y_th = 0;
            double value1, value2;
            while (y_th < delY.Length-1)
            {
                value1 = delY[y_th];
                value2 = delY[y_th+1];
                for (i = y_th; i < delY.Length-1; i++)
                {
                    delY[i+1] = value2 - value1;
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
            double p = (x - valueOfX[0]) / h;
            Result = delY[0];
            for(i=1; i<length; i++)
            {
                Result += (get_p_term(i, p) / factorial(i)) * delY[i];
            }
        }

        private double factorial(double number)
        {
            if (number <= 1) { return 1; }
            return number * factorial(--number);
        }
        private double get_p_term(int nth, double p)
        {
            if (nth <= 1) { return p; }
            for (i=1; i<nth; i++)
            {
                p *= (p - i);
            }
            return p;
        }
    }
}