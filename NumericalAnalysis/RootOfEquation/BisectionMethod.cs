using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace NumericalAnalysis.RootOfEquation
{
    class BisectionMethod : IRootFinder
    {
        private double pointA = 5;
        private double pointB = 6;
        public Equation Equation { get; set; }
        public double Accuracy { get; set; }

        public void GetRoot()
        {
            int step = 1;
            FindPoint();
            double c = (pointA + pointB) / 2;
            double fOfC = Equation.F(c);
            string update = "";
            WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}", "Step", "a", "f{a)", "b", "f(b)", "c", "f(c)", "Update");

            do
            {
                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}",
                     step++, pointA.ToString("0.00000"),
                     Equation.F(pointA).ToString("0.00000"),
                     pointB.ToString("0.00000"),
                     Equation.F(pointB).ToString("0.00000"),
                     c.ToString("0.00000"),
                     fOfC.ToString("0.000000"),
                     update);
                if (fOfC == 0)
                {
                    break;
                }
                else if ((Equation.F(pointA) * fOfC) < 0)
                {
                    pointB = c;
                    update = "b=c";
                }
                else if ((Equation.F(pointB) * fOfC) < 0)
                {
                    pointA = c;
                    update = "a=c";
                }
                c = (pointA + pointB) / 2;
                fOfC = Equation.F(c);
            }
            while (c != 0 && Math.Abs(fOfC) >= Accuracy) ;
            WriteLine();
            WriteLine($"Approximate root of the equation {Equation.Variable1.Coefficient}x{Equation.Variable1.Pow} + " +
                $"{Equation.Variable2.Coefficient}x{Equation.Variable2.Pow} + {Equation.ConstVal} using Bisection method is " +
                $"{c:0.000000}");
        }

        public void FindPoint()
        {
            if (Equation is null) { throw new Exception("Equation not found!"); }
            double multiplicationOfFofAB = Equation.F(pointA) * Equation.F(pointB);
            while (multiplicationOfFofAB > 0)
            {
                pointA++;
                pointB++;
                multiplicationOfFofAB = Equation.F(pointA) * Equation.F(pointB);
            }
        }
    }
}
