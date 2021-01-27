using NumericalAnalysis.RootOfEquation.LabTask;
using static System.Console;

namespace NumericalAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            BisectionMethod bm = new BisectionMethod();
            bm.GetRoot();
        }
    }
}
