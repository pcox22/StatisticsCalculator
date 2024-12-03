namespace StatCalcTest;

public class Tests
{
    [Test]
    public void DifferenceTest()
    {
        var x = 7;
        var y = 2.5;
        
        var result = LogicModule.Statistics.Difference(x, y);
        
        Assert.That(result, Is.EqualTo(4.5d));
    }

    [Test]
    public void CalculateMeanTest()
    {
        var test1 = new List<double> { 3, 4 };
        
        var result = LogicModule.Statistics.CalculateMean(test1);
        
        Assert.That(result, Is.EqualTo(3.5d));
    }

    [Test]
    public void SquareOfDifferencesTest()
    {
        var test2 = new List<double> { 5, 4, 7, 12 };
        
        var mean = LogicModule.Statistics.CalculateMean(test2);
        var result = LogicModule.Statistics.ComputeSquareOfDifferences(test2, mean);
        
        Assert.That(result, Is.EqualTo(38));
    }

    [Test]
    public void ComputeVarianceTestSample()
    {
        var test3 = new List<double> { 9, 6, 8, 5, 7 };
        
        var mean = LogicModule.Statistics.CalculateMean(test3);
        var sqOfDif = LogicModule.Statistics.ComputeSquareOfDifferences(test3, mean);
        var result = LogicModule.Statistics.ComputeVariance(sqOfDif, test3.Count, false);
        
        Assert.That(result, Is.EqualTo(2.5d));
    }

    [Test]
    public void ComputeVarianceTestPopulation()
    {
        var test3 = new List<double> { 9, 6, 8, 5, 7 };
        
        var mean = LogicModule.Statistics.CalculateMean(test3);
        var sqOfDif = LogicModule.Statistics.ComputeSquareOfDifferences(test3, mean);
        var result = LogicModule.Statistics.ComputeVariance(sqOfDif, test3.Count, true);
        
        Assert.That(result, Is.EqualTo(2d));
    }

    [Test]
    public void ComputeStandardDeviationTestSample()
    {
        var test4 = new List<double> { 9, 6, 8, 5, 7 };
        
        var result = Math.Round(LogicModule.Statistics.ComputeStandardDeviation(test4, false), 5);
        
        Assert.That(result, Is.EqualTo(1.58114d));
    }

    [Test]
    public void ComputeStandardDeviationTestPopulation()
    {
        var test4 = new List<double> { 9, 6, 8, 5, 7 };
        
        var result = Math.Round(LogicModule.Statistics.ComputeStandardDeviation(test4, true), 5);
        
        Assert.That(result, Is.EqualTo(1.41421d));
    }

    [Test]
    public void SampleStandardDeviationTest()
    {
        var test4 = new List<double> { 9, 6, 8, 5, 7 };
        
        var result = Math.Round(LogicModule.Statistics.ComputeSampleStandardDeviation(test4), 5);
        
        Assert.That(result, Is.EqualTo(1.58114d));
    }

    [Test]
    public void PopulationStandardDeviationTest()
    {
        var test4 = new List<double> { 9, 6, 8, 5, 7 };

        var result = Math.Round(LogicModule.Statistics.ComputePopulationStandardDeviation(test4), 5);

        Assert.That(result, Is.EqualTo(1.41421d));
    }
    
    [Test]
    public void ZScoreTest1()
    {
        var result = LogicModule.Statistics.ZScore(5.5d, 7d, 3.060787652326d);
        result = Math.Round(result, 5);
        Assert.That(result, Is.EqualTo(-0.49007d));
    }
    
    [Test]
    public void ZScoreTest2()
    {
        var list = new List<double> { 5.5d, 7d, 3.060787652326d};
        var result = LogicModule.Statistics.ComputeZScore(list);
        result = Math.Round(result, 5);
        Assert.That(result, Is.EqualTo(-0.49007d));
    }

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
        
        Assert.That(result, Is.EqualTo("y = 0.8817204301075269x + -0.043010752688172005"));
    }

    [Test]
    public void ComputeForYTest()
    {
        var result = LogicModule.LinearRegression.ComputeForY(1.535d, 61.272186542107434d, -39.061955918838656d);
        
        Assert.That(result, Is.EqualTo(54.990850423296244d));
    }
}
