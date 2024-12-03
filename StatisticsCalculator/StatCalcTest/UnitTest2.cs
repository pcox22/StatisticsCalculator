using NUnit.Framework.Internal;

namespace StatCalcTest;

public class UnitTest2
{
    [Test]
    public void ComputeSumTest()
    {
        var test5 = new List<double> { 5, 2, 8, 7, 10 };
        
        var result = LogicModule.LinearRegression.ComputeSum(test5);
        
        Assert.That(result, Is.EqualTo(32.0d));
    }

    [Test]
    public void ComputeSquaredSum1Test()
    {
        var test5 = new List<double> { 5, 2, 8, 7, 10 };
        
        var result = LogicModule.LinearRegression.ComputeSquaredSum(test5);
        
        Assert.That(result, Is.EqualTo(242.0d));
    }

    [Test]
    public void ComputeSquaredSum2Test()
    {
        var test5A = new List<double> { 5, 2, 8, 7, 10 };
        var test5B = new List<double> { 4, 2, 7, 6, 9 };
        
        var result = LogicModule.LinearRegression.ComputeSquaredSum(test5A, test5B);
        
        Assert.That(result, Is.EqualTo(212.0d));
    }

    [Test]
    public void ComputeSlopeTest()
    {
        var test5A = new List<double> { 5, 2, 8, 7, 10 };
        var test5B = new List<double> { 4, 2, 7, 6, 9 };
        
        var result = LogicModule.LinearRegression.ComputeSlope(
            5,
            LogicModule.LinearRegression.ComputeSum(test5A),
            LogicModule.LinearRegression.ComputeSum(test5B),
            LogicModule.LinearRegression.ComputeSquaredSum(test5A, test5B),
            LogicModule.LinearRegression.ComputeSquaredSum(test5A)
        );

        Assert.That(result, Is.EqualTo(0.8817204301075269d));
    }

    [Test]
    public void ComputeInterceptTest()
    {
        var test5A = new List<double> { 5, 2, 8, 7, 10 };
        var test5B = new List<double> { 4, 2, 7, 6, 9 };
        
        var result = LogicModule.LinearRegression.ComputeIntercept(
            5,
            LogicModule.LinearRegression.ComputeSlope(
                5,
                LogicModule.LinearRegression.ComputeSum(test5A),
                LogicModule.LinearRegression.ComputeSum(test5B),
                LogicModule.LinearRegression.ComputeSquaredSum(test5A, test5B),
                LogicModule.LinearRegression.ComputeSquaredSum(test5A)
            ),
            LogicModule.LinearRegression.ComputeSum(test5A),
            LogicModule.LinearRegression.ComputeSum(test5B)
        );

        Assert.That(result, Is.EqualTo(-0.043010752688172005d));
    }

    [Test]
    public void LinearRegressionEquationTest()
    {
        var test5A = new List<double> { 5, 2, 8, 7, 10 };
        var test5B = new List<double> { 4, 2, 7, 6, 9 };
        
        var result = LogicModule.LinearRegression.ComputeLinearEquation(test5A, test5B);
        
        Assert.That(result, Is.EqualTo("Y = 0.8817204301075269x + -0.043010752688172005"));
    }

    [Test]
    public void ComputeForYTest()
    {
        var result = LogicModule.LinearRegression.ComputeForY(1.535d, 61.272186542107434d, -39.061955918838656d);
        
        Assert.That(result, Is.EqualTo(54.990850423296244d));
    }
}