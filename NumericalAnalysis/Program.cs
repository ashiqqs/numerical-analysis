using NumericalAnalysis.RootOfEquation;
using System;

namespace NumericalAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Equation eq = new Equation();
            eq.Variable1 = (1, 3);
            eq.Variable2 = (-1, 1);
            eq.ConstVal = -1;

            BisectionMethod bm = new BisectionMethod();
            bm.Accuracy = 0.00001;
            bm.Equation = eq;
            double root = bm.GetRoot();
        }
    }
}
