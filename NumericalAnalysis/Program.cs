using NumericalAnalysis.RootOfEquation.LabTask;
using NumericalAnalysis.RootOfEquation;
using NumericalAnalysis.Interpolation;
using static System.Console;
using NumericalAnalysis.Integral;

namespace NumericalAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            // BisectionMethod bm = new BisectionMethod();
            // bm.GetRoot();

            //Equation eq = new Equation();
            //eq.Variable1 = (2,3);
            //eq.Variable2 = (-5,1);
            //eq.ConstVal = 25;

            //IRootFinder fpm = new FalsePositionMethod();
            //fpm.Accuracy = 0.00001;
            //fpm.Equation = eq;

            //fpm.GetRoot();

            //NewtonRaphsonMethod nrm = new NewtonRaphsonMethod();
            //nrm.GetRoot();

            //GregoryNewtonForward gnf = new GregoryNewtonForward();
            //WriteLine("Gregory Newton Forward Formula: ");
            //WriteLine("---------------------------------");
            //gnf.TakeInput();
            //gnf.BuildDiffTable();
            //gnf.ApplyFormula();
            //WriteLine("Calculating...");
            //WriteLine("---------------------------------");
            //WriteLine("Result y = " + gnf.Result);

            //GregoryNewtonBackward gnb = new GregoryNewtonBackward();
            //WriteLine("Gregory Newton Backward Formula: ");
            //WriteLine("---------------------------------");
            //gnb.TakeInput();
            //gnb.BuildDiffTable();
            //gnb.ApplyFormula();
            //WriteLine("Calculating...");
            //WriteLine("---------------------------------");
            //WriteLine("Result y = " + gnb.Result);

            //NewtonDevidedDifference ndd = new NewtonDevidedDifference();
            //WriteLine("Newton Devided Difference Formula: ");
            //WriteLine("---------------------------------");
            //ndd.TakeInput();
            //ndd.BuildDiffTable();
            //ndd.ApplyFormula();
            //WriteLine("Calculating...");
            //WriteLine("---------------------------------");
            //WriteLine("Result y = " + ndd.Result);

            //LagrangesInterpolation li = new LagrangesInterpolation();
            //WriteLine("Lagrange Interpolation Formula: ");
            //WriteLine("---------------------------------");
            //li.TakeInput();
            //li.ApplyFormula();
            //WriteLine("Calculating...");
            //WriteLine("---------------------------------");
            //WriteLine("Result y = " + li.Result);

            TrapezoidalRule tr = new TrapezoidalRule();
            WriteLine("Trapezoidal Rule: ");
            WriteLine("---------------------------------");
            tr.TakeInput();
            tr.ApplyFormula();
            WriteLine("Calculating...");
            WriteLine("---------------------------------");
            WriteLine("Result y = " + tr.Result);
        }
    }
}
