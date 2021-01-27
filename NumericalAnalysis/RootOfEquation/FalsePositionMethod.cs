using System;
using static System.Console;

namespace NumericalAnalysis.RootOfEquation
{
    public class FalsePositionMethod : IRootFinder
    {
        private double pointX0 = 5;
        private double pointX1 = 6;
        public Equation Equation { get; set; }
        public double Accuracy { get; set; }

        public void FindPoint()
        {
            if (Equation is null) { throw new Exception("Equation not found!"); }
            double multiplicationOfFofAB = Equation.F(pointX0) * Equation.F(pointX1);
            while (multiplicationOfFofAB > 0)
            {
                pointX0++;
                pointX1++;
                multiplicationOfFofAB = Equation.F(pointX0) * Equation.F(pointX1);
            }
        }

        public void GetRoot()
        {
            int step = 1;
            FindPoint();
            double x2 = pointX0 - 
                (Equation.F(pointX0) * 
                ((pointX1 - pointX0) / (Equation.F(pointX1) - Equation.F(pointX0))
                ));
            double fOfC = Equation.F(x2);
            string update = "";
            WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}", "Step", "a", "f(a)", "b", "f(b)", "c", "f(c)", "Update");

            do
            {
                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}",
                     step++, pointX0.ToString("0.00000"),
                     Equation.F(pointX0).ToString("0.00000"),
                     pointX1.ToString("0.00000"),
                     Equation.F(pointX1).ToString("0.00000"),
                     x2.ToString("0.00000"),
                     fOfC.ToString("0.000000"),
                     update);
                if (fOfC == 0)
                {
                    break;
                }
                else if ((Equation.F(pointX0) * fOfC) < 0)
                {
                    pointX1 = x2;
                    update = "x1=x2";
                }
                else if ((Equation.F(pointX1) * fOfC) < 0)
                {
                    pointX0 = x2;
                    update = "x0=x2";
                }
                x2 = pointX0 -
                (Equation.F(pointX0) *
                ((pointX1 - pointX0) / (Equation.F(pointX1) - Equation.F(pointX0))
                ));
                fOfC = Equation.F(x2);
            }
            while (x2 != 0 && Math.Abs(fOfC) >= Accuracy) ;
            
            WriteLine();
            WriteLine($"Approximate root of the equation {Equation.Variable1.Coefficient}x{Equation.Variable1.Pow} + " +
                $"{Equation.Variable2.Coefficient}x{Equation.Variable2.Pow} + {Equation.ConstVal} using False Position method is " +
                $"{x2:0.000000}");
        }
    }
}
