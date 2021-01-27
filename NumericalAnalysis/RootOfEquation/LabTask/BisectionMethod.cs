using System;
using static System.Console;

namespace NumericalAnalysis.RootOfEquation.LabTask
{
    public class BisectionMethod{
        private double accuracy;
        private double a;
        private double b;

        private double Func(double x){
            //f(x) =  4x^3 - 3x^2 + 2x - 25
            return (
                (4*Math.Pow(x,3)) - (3*Math.Pow(x,2)) + 2*x - 25
            );
        }
        public void FindPoint(){
            while(true){
                Write("Enter point a: ");
                a = int.Parse(ReadLine());
                Write("Enter point b: ");
                b = int.Parse(ReadLine());
                if(a<b && (Func(a)*Func(b))<0){
                    return;
                }
                WriteLine("Invalid selection, Try again");
            }
        }
        public void GetRoot()
        {
            Write("Enter accuracy: ");
            accuracy = double.Parse(ReadLine());
            FindPoint();
            int step = 1;
            double c = (a + b) / 2;
            double fOfC = Func(c);
            string update = "";
            WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}", "Step", "a", "f{a)", "b", "f(b)", "c", "f(c)", "Update");

            do
            {
                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}",
                     step++, a.ToString("0.00000"),
                     Func(a).ToString("0.00000"),
                     b.ToString("0.00000"),
                     Func(b).ToString("0.00000"),
                     c.ToString("0.00000"),
                     fOfC.ToString("0.000000"),
                     update);
                if (fOfC == 0)
                {
                    break;
                }
                else if ((Func(a) * fOfC) < 0)
                {
                    b = c;
                    update = "b=c";
                }
                else if ((Func(b) * fOfC) < 0)
                {
                    a = c;
                    update = "a=c";
                }
                c = (a + b) / 2;
                fOfC = Func(c);
            }
            while (c != 0 && Math.Abs(fOfC) >= accuracy) ;
            WriteLine();
            WriteLine($"Approximate root of the equation 4x^3 - 3x^2 + 2x - 25 using Bisection method is " +
                $"{c:0.000000}");
        }
    }
}