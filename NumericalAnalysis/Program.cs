using NumericalAnalysis.RootOfEquation.LabTask;
using NumericalAnalysis.RootOfEquation;
using NumericalAnalysis.Interpolation;
using static System.Console;

namespace NumericalAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            // BisectionMethod bm = new BisectionMethod();
            // bm.GetRoot();

            Equation eq = new Equation();
            eq.Variable1 = (2,3);
            eq.Variable2 = (-5,1);
            eq.ConstVal = 25;

            IRootFinder fpm = new FalsePositionMethod();
            fpm.Accuracy = 0.00001;
            fpm.Equation = eq;

            //fpm.GetRoot();

            NewtonRaphsonMethod nrm = new NewtonRaphsonMethod();
            //nrm.GetRoot();

            GregoryNewtonForward gnf = new GregoryNewtonForward();
            gnf.TakeInput();
            gnf.BuildDiffTable();
            gnf.ApplyFormula();
            WriteLine("---------------------------------");
            WriteLine("Result y = " + gnf.Result);
        }
    }
}
