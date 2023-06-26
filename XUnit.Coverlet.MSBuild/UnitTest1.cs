using Xunit;
using SquareEquationLib;

namespace SquareEquation.Tests;
public class UnitTest1
{
    [Theory]
    [InlineData(0, 2, 1)]
    [InlineData(double.PositiveInfinity, 2, 1)]
    [InlineData(1, double.PositiveInfinity, 2)]
    [InlineData(1, 2, double.PositiveInfinity)]
    [InlineData(double.NaN, 2, 1)]
    [InlineData(1, double.NaN, 1)]
    [InlineData(1, 2, double.NaN)]
    [InlineData(double.NegativeInfinity, 2, 1)]
    [InlineData(1, double.NegativeInfinity, 1)]
    [InlineData(2, 1, double.NegativeInfinity)]
    public void SquareEquationTest_Exception(double a, double b, double c){
        try{
            double[] result = SquareEquationLib.SquareEquation.Solve(a, b, c);
        } catch (Exception error){
            Assert.Equal(error.GetType(), new ArgumentException().GetType());
        }
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-4, -2, -1)]
    public void SquareEquationTest_NoRoots(double a, double b, double c)
    {
        double[] result = SquareEquationLib.SquareEquation.Solve(a, b, c);
        Assert.True(result.Length == 0);
    }

    [Theory]
    [InlineData(1, 6, 9, new double[] { -3 })]
    [InlineData(2, 12, 18, new double[] { -12 })]
    public void SquareEquationTest_OneRoots(double a, double b, double c, double[] rightRoots)
    {
        double[] result = SquareEquationLib.SquareEquation.Solve(a, b, c);
        Assert.Equal(rightRoots, result);
    }

    [Theory]
    [InlineData(1, -3, 2, new double[] { 2, 1 })]
    [InlineData(1, -5, 6, new double[] { 3, 2})]
    public void SquareEquationTest_TwoRoots(double a, double b, double c, double[] rightRoots)
    {
        double[] result = SquareEquationLib.SquareEquation.Solve(a, b, c);
        Assert.Equal(rightRoots, result);
    }

}