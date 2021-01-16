using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace NumericalAnalysis.RootOfEquation
{
    class BisectionMethod : IRootFinder
    {
        private double pointA = 0;
        private double pointB = 1;
        public Equation Equation { get; set; }
        public double Accuracy { get; set; }
        public double GetRoot()
        {
            int step = 1;
            FindPointOfA_B();
            double c = (pointA + pointB) / 2;
            double fOfC = Equation.GetEquationVal(c);
            string update = "";
            WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}", "#SN", "a", "f{b)", "b", "f(b)", "c", "f(c)", "Update");

            do
            {
                if (fOfC == 0)
                {
                    return c;
                }
                else if ((Equation.GetEquationVal(pointA) * fOfC) < 0)
                {
                    pointB = c;
                    update = "b=c";
                }
                else if ((Equation.GetEquationVal(pointB) * fOfC) < 0)
                {
                    pointA = c;
                    update = "a=c";
                }
                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}",
                     step++, pointA.ToString("0.00000"),
                     Equation.GetEquationVal(pointA).ToString("0.00000"),
                     pointB.ToString("0.00000"),
                     Equation.GetEquationVal(pointB).ToString("0.00000"),
                     c.ToString("0.00000"),
                     fOfC.ToString("0.00000"),
                     update);
                c = (pointA + pointB) / 2;
                fOfC = Equation.GetEquationVal(c);
            }
            while (c != 0 && Math.Abs(fOfC) >= Accuracy);
            
            return c;
        }

        public void FindPointOfA_B()
        {
            if (Equation is null) { throw new Exception("Equation not found!"); }
            double multiplicationOfFofAB = Equation.GetEquationVal(pointA) * Equation.GetEquationVal(pointB);
            while (multiplicationOfFofAB > 0)
            {
                pointA++;
                pointB++;
                multiplicationOfFofAB = Equation.GetEquationVal(pointA) * Equation.GetEquationVal(pointB);
            }
        }
    }
}
