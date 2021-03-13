using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalAnalysis.RootOfEquation
{
    public class Equation
    {
        public (int Coefficient, int Pow) Variable1 { get; set; }
        public (int Coefficient, int Pow) Variable2 { get; set; }
        public int ConstVal { get; set; }

        public double F(double valueOfVariable)
        { 
            double result = (
                Variable1.Coefficient * Math.Pow(valueOfVariable, Variable1.Pow) +
                Variable2.Coefficient * Math.Pow(valueOfVariable, Variable2.Pow) +
                ConstVal
                );
            return result;
        }
        


    }
}
