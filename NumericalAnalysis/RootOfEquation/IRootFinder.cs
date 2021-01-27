using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalAnalysis.RootOfEquation
{
    public interface IRootFinder
    {
        Equation Equation { get; set; }
        double Accuracy { get; set; }
        void GetRoot();
        void FindPoint();

    }
}
