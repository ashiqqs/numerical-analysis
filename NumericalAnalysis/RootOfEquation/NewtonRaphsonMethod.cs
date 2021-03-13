/*
 Author: Ahsiq;
 Lab Report: 04;
 delegate: 26/02/2021;
 */
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace NumericalAnalysis.RootOfEquation
{
    class NewtonRaphsonMethod
    {
        const string equation = "f(x) = 2x^3-5x+25";
        private double pointA = 5;
        private double pointB = 6;
        public double accuracy = 0.00001;

        private double f(double x)
        {
            //f(x) = 2x^3-5x+25
            return (2 * x * x * x) - (5 * x) + 25;
        }
        private double _f(double x)
        {
            //f(x) = 2x^3-5x+25
            //f`(x) = 6x^2-5
            return (6 * x * x) - 5;
        }
        public void GetRoot()
        {
            FindPoint();
            Write("Enter Accuracy: ");
            this.accuracy = double.Parse(ReadLine());
            int step = 1;
            double Xo = (pointA + pointB) / 2;
            double f;
            double _f = this._f(Xo);
            double X1;
            string update = "";
            WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10}", "Step", "Xo", "f(Xo)", "f`(Xo)", "X1", "Update");

            do
            {
                f = this.f(Xo);
                _f = this._f(Xo);
                X1 = Xo - (f / _f);
                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("{0,-5} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10}",
                     step++, Xo.ToString("0.00000"),
                     f.ToString("0.00000"),
                     _f.ToString("0.00000"),
                     X1.ToString("0.00000"),
                     update);
                if (this.f(X1) == 0)
                {
                    break;
                }
                else
                {
                    Xo = X1;
                }
            }
            while (this.f(X1) != 0 && Math.Abs(this.f(X1)) >= this.accuracy);
            WriteLine();
            WriteLine($"Approximate root of the equation 2x^3-5x+25 using Newton Raphson method is " +
                $"{X1:0.000000}");
        }

        public void FindPoint()
        {
            WriteLine("Given: " + equation);
            double multiplicationOfFofAB;
            while (true)
            {
                Write("Enter Point-A: ");
                this.pointA = int.Parse(ReadLine());
                Write("Enter Point-B: ");
                this.pointB = int.Parse(ReadLine());
                multiplicationOfFofAB = f(pointA) * f(pointB);
                if (this.pointA < this.pointB && multiplicationOfFofAB < 0)
                {
                    return;
                }
                else
                {
                    WriteLine("InvalidPoint Selection. Try Again!");
                }
            }
        }
    }
}
