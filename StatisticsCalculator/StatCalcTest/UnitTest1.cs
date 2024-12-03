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
    public void ZScoreTest()
    {
        var result = Math.Round(LogicModule.Statistics.ZScore(7d, 9d, 2.7d), 2);
        
        Assert.That(result, Is.EqualTo(-0.74d));
    }

    
    
}
