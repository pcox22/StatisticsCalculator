namespace LogicModule;

public class Statistics
{
    public static double Difference(double a, double b)
    {
        return a - b;
    }
    //calculate mean
    public static double CalculateMean(List<double> valuesList)
    {
        int sumAccumulator = 0;
        if (valuesList.Count== 0)
        {
            //should throw an error
            throw new ArgumentException("valuesList parameter cannot be null or empty");
        }

        foreach (int value in valuesList)
        {
            sumAccumulator = sumAccumulator + value;
        }

        // # Return the average (sum divided by the number of values we accumulated)
        return (double)sumAccumulator / valuesList.Count;
    }
    
    // Function to compute the sum of squared differences from the mean
    public static double ComputeSquareOfDifferences(List<double> valuesList, double mean)
    {
        double squareAccumulator = 0.0d;
        if (valuesList.Count == 0)
        {
            //should throw an error
            Console.WriteLine("valuesList parameter cannot be null or empty");
        }
        else
        {
            foreach (int value in valuesList)
            {
                double difference = Difference(value, mean);
                double squareOfDifference = difference * difference;
                squareAccumulator += squareOfDifference;
            }
        }

        return squareAccumulator;
    }
    
    public static double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        // # Adjust number of values by minus one if sample where sample is indicated by (not isPopulation)
        // # https://www.quora.com/On-the-sample-standard-deviation-why-do-we-subtract-N-by-1
        if (!isPopulation)
        {
            numValues -= 1;
        }
        if (numValues < 1)
        {
            //should throw error: temp print
            Console.WriteLine("numValues is too low (sample size must be >= 2, population size must be >= 1)");
        }

        return squareOfDifferences / numValues;
    }
    
    public static double ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        double variance = 0;
        if (valuesList.Count == 0)
        {
            //should throw error: temp print
            throw new ArgumentException("valuesList parameter cannot be null or empty");
        }
        else
        {
            double mean = CalculateMean(valuesList);
            double squareOfDifferences = ComputeSquareOfDifferences(valuesList, mean);
            variance = ComputeVariance(squareOfDifferences, valuesList.Count, isPopulation);
        }

        return Math.Sqrt(variance);
    }
    public static double ComputeSampleStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, false);
    }
    
    public static double ComputePopulationStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, true);
    }
    
    
}