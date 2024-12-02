namespace StatCalcTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DifferenceTest()
    {
        Assert.That(LogicModule.Statistics.Difference(7, 2.5), Is.EqualTo(4.5d));
    }

    [Test]
    public void CalculateMeanTest()
    {
        //Assert.Pass();
        List<double> test1= new List<double>();
        test1.Add(3);
        test1.Add(4);
        Assert.That(LogicModule.Statistics.CalculateMean(test1), Is.EqualTo(3.5d));
    }

    [Test]
    public void SquareOfDifferencesTest()
    {
        List<double> test2= new List<double>();
        test2.Add(5);
        test2.Add(4);
        test2.Add(7);
        test2.Add(12);
        double mean = LogicModule.Statistics.CalculateMean(test2);
        Assert.That(LogicModule.Statistics.ComputeSquareOfDifferences(test2, mean), Is.EqualTo(38));
    }
    
    [Test]
    public void ComputeVarianceTestSample()
    {
        List<double> test3= new List<double>();
        test3.Add(9);
        test3.Add(6);
        test3.Add(8);
        test3.Add(5);
        test3.Add(7);
        double mean = LogicModule.Statistics.CalculateMean(test3);
        double sqofDif = LogicModule.Statistics.ComputeSquareOfDifferences(test3, mean);
        Assert.That(LogicModule.Statistics.ComputeVariance(sqofDif,test3.Count,false), Is.EqualTo(2.5d));
    }
    
    [Test]
    public void ComputeVarianceTestPopulation()
    {
        List<double> test3= new List<double>();
        test3.Add(9);
        test3.Add(6);
        test3.Add(8);
        test3.Add(5);
        test3.Add(7);
        double mean = LogicModule.Statistics.CalculateMean(test3);
        double sqofDif = LogicModule.Statistics.ComputeSquareOfDifferences(test3, mean);
        Assert.That(LogicModule.Statistics.ComputeVariance(sqofDif,test3.Count,true), Is.EqualTo(2d));
    }
    
    [Test]
    public void ComputeStandardDeviationTestSample()
    {
        List<double> test4= new List<double>();
        test4.Add(9);
        test4.Add(6);
        test4.Add(8);
        test4.Add(5);
        test4.Add(7);
        Assert.That(Math.Round(LogicModule.Statistics.ComputeStandardDeviation(test4, false),5), Is.EqualTo(1.58114d));
    }
    
    [Test]
    public void ComputeStandardDeviationTestPopulation()
    {
        List<double> test4= new List<double>();
        test4.Add(9);
        test4.Add(6);
        test4.Add(8);
        test4.Add(5);
        test4.Add(7);
        Assert.That(Math.Round(LogicModule.Statistics.ComputeStandardDeviation(test4, true),5), Is.EqualTo(1.41421d));
    }

    [Test]
    public void SampleStandardDeviationTest()
    {
        List<double> test4= new List<double>();
        test4.Add(9);
        test4.Add(6);
        test4.Add(8);
        test4.Add(5);
        test4.Add(7);
        Assert.That(Math.Round(LogicModule.Statistics.ComputeSampleStandardDeviation(test4),5), Is.EqualTo(1.58114d));
    }
    
    [Test]
    public void PopulationStandardDeviationTest()
    {
        List<double> test4= new List<double>();
        test4.Add(9);
        test4.Add(6);
        test4.Add(8);
        test4.Add(5);
        test4.Add(7);
        Assert.That(Math.Round(LogicModule.Statistics.ComputePopulationStandardDeviation(test4),5), Is.EqualTo(1.41421d));
    }

    [Test]
    public void ZScoreTest()
    {
        Assert.That(Math.Round(LogicModule.Statistics.ZScore(7d, 9d, 2.7d), 2), Is.EqualTo(-0.74d));
    }
    
    
}