﻿namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double e = 1e-9;
        if ((-e < a & a < e) || double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
        {
            throw new ArgumentException();
        }
        double D = b * b - 4 * a * c;
        if (D <= -e)
        {
            return new double[] { };
        }
        else if (-e < D & D < e)
        { 
            return new double[] {(-b) / 2*a};
        }
        else{
            double x1;
            double x2;
            if (c <= e)
            {
                x1 = Math.Pow(Math.Abs(c),0.5);
                x2 = -Math.Pow(Math.Abs(c),0.5);
            }
            else {
                x1 = (-b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                x2 = c / x1;
            }
            return new double[] {x1, x2};
            
        }
    }
}

