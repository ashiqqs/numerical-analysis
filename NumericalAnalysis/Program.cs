using NumericalAnalysis.RootOfEquation;
using static System.Console;

namespace NumericalAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Equation eq = new Equation
            {
                Variable1 = (1, 3),
                Variable2 = (-1, 1),
                ConstVal = -1
            };

            IRootFinder bm = new BisectionMethod
            {
                Accuracy = 0.00001,
                Equation = eq
            };
            bm.GetRoot();
            WriteLine();
            IRootFinder fpm = new FalsePositionMethod()
            {
                Accuracy = 0.00001,
                Equation = eq
            };
            fpm.GetRoot();
        }
    }
}
