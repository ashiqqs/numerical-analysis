using System;
using static System.Console;

namespace NumericalAnalysis.Interpolation
{
    //To find a missing value from a range or group data
    public class GregoryNewtonBackward
    {
        private int[] valueOfX = { 15,20,25,30,35,40};
        private double[] valueOfY = {.2588190,.3420201,.4226183,.5,.5735764,.6427876};
        private int length=6, i;
        private double x=38, h=5;
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
            int y_th = length-1;
            
            double value1, value2;
            while (y_th >0)
            {
                value1 = delY[y_th];
                value2 = delY[y_th-1];
                for (i = y_th; i >0; i--)
                {
                    delY[i-1] = value1-value2;
                    value1 = value2;
                    if (i > 1)
                    {
                        value2 = delY[i - 2];
                    }
                }
                y_th--;
            }
            return delY;
        }

        public void ApplyFormula()
        {
            double p = (x - valueOfX[length-1]) / h;
            Result = delY[length-1];
            int j;
            for(i=length-2, j=1; i>=0 && j<length; i--,j++)
            {
                Result += (get_p_term(j, p) / factorial(j)) * delY[i];
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